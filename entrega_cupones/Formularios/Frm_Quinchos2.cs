using entrega_cupones.Clases;
using entrega_cupones.Metodos;
using entrega_cupones.Modelos;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace entrega_cupones
{
  public partial class Frm_Quinchos2 : Form
  {
    public int _UsuarioId;
    public string _UsuarioName;
    public string _DNI;
    public string _CUIL;
    public long _CUIT;
    public int _SocioId;
    public int _NroSocio;
    public string _RazonSocial;
    public int _NroAturizacion;
    public int _NroAutomatico;

    public DS_cupones ds = new DS_cupones();
    public DataTable DtArticulos;

    // DataRow dr = dt.NewRow();


    public Frm_Quinchos2()
    {
      InitializeComponent();
    }

    private void frm_quinchos_Load(object sender, EventArgs e)
    {
      dgv_reservados.AutoGenerateColumns = false;
      dgv_reservados.DataSource = MtdReservasQuinchos.GetReservasQuinchos(dtp_consulta.Value.Date);
      cargar_cbx_eventos();
      Cargar_cbx_Beneficiarios();
      Dgv_Articulos.AutoGenerateColumns = false;
      PintarReservados(); Dgv_Articulos.DataSource = MtdArticulos.GetArticulosReserva();
    }

    private void cargar_cbx_eventos()
    {
      cbx_eventos.DisplayMember = "Nombre";
      cbx_eventos.ValueMember = "Id";
      cbx_eventos.DataSource = MtdEventos.get_todos();
    }

    private void Cargar_cbx_Beneficiarios()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var Benef = from sf in context.socflia.Where(x => x.SOCFLIA_CUIL == Convert.ToDouble(_CUIL))
                    join mf in context.maeflia on sf.SOCFLIA_CODFLIAR equals mf.MAEFLIA_CODFLIAR
                    select new MdlBenef
                    {
                      Id = (int)mf.MAEFLIA_CODFLIAR,
                      ApeNom = mf.MAEFLIA_APELLIDO.Trim() + " " + mf.MAEFLIA_NOMBRE.Trim()
                    };
        Cbx_Beneficiario.DisplayMember = "ApeNom";
        Cbx_Beneficiario.ValueMember = "Id";
        Cbx_Beneficiario.DataSource = Benef.ToList();
      }
    }

    private void dgv_reservados_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void dtp_consulta_ValueChanged_1(object sender, EventArgs e)
    {
      MostrarReservas();
      CalcularFechaVencReserva();
    }
    private void MostrarSocioQueAlquila()
    {
      if (Convert.ToInt32(dgv_reservados.CurrentRow.Cells["Estado"].Value) == 1 || Convert.ToInt32(dgv_reservados.CurrentRow.Cells["Estado"].Value) == 2)
      {
        mdlSocio DatosSocios = new mdlSocio();
        string NroSocio = dgv_reservados.CurrentRow.Cells["SocioId"].Value.ToString();
        DatosSocios = MtdReservasQuinchos.MostrarSocioQueAlquila(NroSocio);
        Txt_NroSocioAlquila.Text = DatosSocios.NroDeSocio;
        Txt_DniSocioAlquila.Text = DatosSocios.NroDNI;
        Txt_NombreSocioAlquila.Text = DatosSocios.ApeNom;
        Txt_TelefonoSocioAlquila.Text = DatosSocios.Telefono;
        PicBox_SocioAlquila.Image = convertir_imagen.ConvertByteArrayToImage(mtdSocios.get_foto_titular_binary(Convert.ToDouble(DatosSocios.CUIL)).ToArray());
      }
      else
      {
        Txt_NroSocioAlquila.Text = "";
        Txt_DniSocioAlquila.Text = "";
        Txt_NombreSocioAlquila.Text = "";
        Txt_TelefonoSocioAlquila.Text = "";
        PicBox_SocioAlquila.Image = null;
      }
    }

    private void MostrarReservas()
    {
      dgv_reservados.DataSource = MtdReservasQuinchos.GetReservasQuinchos(dtp_consulta.Value.Date);
      PintarReservados();
    }

    private void PintarReservados()
    {
      foreach (DataGridViewRow row in dgv_reservados.Rows)
      {
        //row.DefaultCellStyle.BackColor = row.Cells["EstadoReserva"].Value.ToString() == "Libre" ? Color.GreenYellow : Color.OrangeRed;

        switch (Convert.ToInt32(row.Cells["Estado"].Value))
        {
          case 0: row.DefaultCellStyle.BackColor = Color.FromArgb(124, 204, 126); break;
          case 1: row.DefaultCellStyle.BackColor = Color.Yellow; break;
          case 2: row.DefaultCellStyle.BackColor = Color.FromArgb(248,133,82); break;
          default: row.DefaultCellStyle.BackColor = Color.White; break;
        }
      }
    }
    private void btn_Confirmar_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Esta seguro de Confirmar La Reserva "
        + dgv_reservados.CurrentRow.Cells["Quincho"].Value.ToString()
        + " Para el dia " + dtp_consulta.Value.Date.ToString("d")
        , "¡¡¡ ATENCION !!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        using (var context = new lts_sindicatoDataContext())
        {
          var confirm = (from a in context.reservas_quinchos.Where(x => x.Id == Convert.ToInt32(dgv_reservados.CurrentRow.Cells["reserva_id"].Value)) select a).Single();
          confirm.Estado = 2;
          confirm.FechaDeConfirmacion = DateTime.Now;
          context.SubmitChanges();
          MostrarReservas();
          MessageBox.Show("Reserva Exitosa !!!!!!!!", "ATENCION !!!");
        }
      }
    }

    private void btn_Reservar_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Esta seguro de Confirmar La Reserva "
        + dgv_reservados.CurrentRow.Cells["Quincho"].Value.ToString()
        + " Para el dia " + dtp_consulta.Value.Date.ToString("d")
        , "¡¡¡ ATENCION !!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        InsertReserva();
        btn_Reservar.Enabled = false;
        Btn_EmitirRecibo.Enabled = true;
      }
    }

    private void InsertReserva()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        try
        {
          _NroAturizacion = MtdReservasQuinchos.GetLastNumberRereserva() + 1;
          reservas_quinchos rq = new reservas_quinchos();
          rq.Fecha = dtp_consulta.Value;
          rq.Numero = _NroAturizacion;
          rq.QuinchoId = Convert.ToInt32(dgv_reservados.CurrentRow.Cells["quincho_id"].Value);
          rq.SocioId = _NroSocio;
          rq.EventoId = Convert.ToInt32(cbx_eventos.SelectedValue);
          rq.CantInvitados = Convert.ToInt32(txt_CantInvitados.Text);
          rq.FiestaDesde = Txt_FiestaDesde.Text;
          rq.FiestaHasta = Txt_FiestaHasta.Text;
          rq.LlavesDesde = Txt_LlavesDesde.Text;
          rq.LlavesHasta = Txt_LlaveHasta.Text;
          rq.Comentario = txt_observaciones.Text;

          rq.Estado = 2;

          context.reservas_quinchos.InsertOnSubmit(rq);
          context.SubmitChanges();

          InsertarArticulos();
          Txt_NroAutorizacion.Text = _NroAturizacion.ToString();
          Txt_LavadoVajilla.Focus();

        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.ToString());
          throw;
        }
      }
    }

    private void InsertarArticulos()
    {
      using (var context = new lts_sindicatoDataContext())
      {

        DtArticulos = ds.Articulos;
        DtArticulos.Clear();
        DataRow dr = DtArticulos.NewRow();

        foreach (DataGridViewRow fila in Dgv_Articulos.Rows)
        {

          dr["Cant" + (fila.Index + 1).ToString()] = (Int32)fila.Cells["Cantidad"].Value;
          dr["Art" + (fila.Index + 1).ToString()] = fila.Cells["Descripcion"].Value;

          ArticuloAsignacion ArtAsig = new ArticuloAsignacion();

          ArtAsig.ArituculoId = (Int32)fila.Cells["ArticuloId"].Value;
          ArtAsig.Cantidad = (Int32)fila.Cells["Cantidad"].Value;
          ArtAsig.Reserva_Numero = _NroAturizacion;
          ArtAsig.Reserva_QuinchoId = (Int32)dgv_reservados.CurrentRow.Cells["quincho_id"].Value;
          ArtAsig.Estado = 1;

          context.ArticuloAsignacion.InsertOnSubmit(ArtAsig);
        }
        context.SubmitChanges();
        DtArticulos.Rows.Add(dr);
      }
    }

    private void Txt_Completar_Click(object sender, EventArgs e)
    {
      foreach (DataGridViewRow fila in Dgv_Articulos.Rows)
      {
        fila.Cells["Cantidad"].Value = txt_CantInvitados.Text;
      }
    }

    private void dgv_reservados_SelectionChanged_1(object sender, EventArgs e)
    {
      //txt_Costo.Text = Math.Round(Convert.ToDecimal(dgv_reservados.CurrentRow.Cells["Costo"].Value), 2).ToString();

      int Estado = Convert.ToInt32(dgv_reservados.CurrentRow.Cells["Estado"].Value);
      //Dtp_VencReserva.Value = dtp_consulta.Value.AddDays(3);


      if (Estado == 0) //Libre
      {
        btn_Reservar.Enabled = true;
        // btn_Confirmar.Enabled = false;
        btn_ImprimirReserva.Enabled = false;
        btn_Cancelar.Enabled = false;
      }

      if (Estado == 1) // Reservado
      {
        btn_Reservar.Enabled = false;
        // btn_Confirmar.Enabled = true;
        btn_ImprimirReserva.Enabled = false;
        btn_Cancelar.Enabled = true;
      }

      if (Estado == 2) // Confirmado
      {
        btn_Reservar.Enabled = false;
        // btn_Confirmar.Enabled = false;
       // btn_ImprimirReserva.Enabled = true;
        btn_Cancelar.Enabled = true;
      }
      MostrarSocioQueAlquila();
    }
    private void CalcularFechaVencReserva()
    {
      // Dtp_VencReserva.Value =  Dtp_VencReserva.Value.AddDays(3);
    }



    private void btn_Salir_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void btn_Cancelar_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Esta seguro de CANCELAR La Reserva "
        + dgv_reservados.CurrentRow.Cells["Quincho"].Value.ToString()
        + " Del dia " + dtp_consulta.Value.Date.ToString("d")
        , "¡¡¡ ATENCION !!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        MtdReservasQuinchos.CancelarReserva(Convert.ToInt32(dgv_reservados.CurrentRow.Cells["reserva_id"].Value), Convert.ToInt32(dgv_reservados.CurrentRow.Cells["Estado"].Value));
        MostrarReservas();
        MessageBox.Show("Reserva CANCELADA !!!!!!!!", "ATENCION !!!");
      }
    }

    private void btn_ImprimirReserva_Click(object sender, EventArgs e)
    {
      ImprimirReserva();
    }


    private void ImprimirReserva()
    {
      using (var context = new lts_sindicatoDataContext())
      {

        DS_cupones ds = new DS_cupones();

        DataTable dt = ds.OrdenResevaQuincho;
        dt.Clear();
        DataRow dr = dt.NewRow();

        dr["FechaDeReserva"] = DateTime.Now;
        dr["NroSocio"] = _NroSocio;
        dr["Evento"] = cbx_eventos.Text;
        dr["CantInvitados"] = txt_CantInvitados.Text;
        dr["Costo"] = Txt_Total.Text;
        dr["Comentario"] = txt_observaciones.Text;
        dr["Quincho"] = dgv_reservados.CurrentRow.Cells["quincho"].Value.ToString();
        dr["NombreSocio"] = txt_Nombre.Text;
        dr["DNISocio"] = txt_DNI.Text.Trim();
        dr["RazonSocial"] = Txt_Comercio.Text.Trim();
        dr["Beneficiario"] = Cbx_Beneficiario.Text;
        dr["FechaEvento"] = dtp_consulta.Value;
        dr["HoraDesde"] = Txt_FiestaDesde.Text;
        dr["HoraFin"] = Txt_FiestaHasta.Text;
        dr["LlaveDesde"] = Txt_LlavesDesde.Text;
        dr["LlaveHasta"] = Txt_LlaveHasta.Text;
        dr["SeguroVajilla"] = Txt_LavadoVajilla.Text;
        dr["LimpiezaQuincho"] = Txt_LimpiezaQuincho.Text;
        dr["Recibo"] = _NroAutomatico.ToString();
        dr["Comentario"] = txt_observaciones.Text;
        dr["NroAutorizacion"] = _NroAturizacion.ToString();


        dt.Rows.Add(dr);

        reportes F_Reportes = new reportes();
        F_Reportes.dt = dt;
        F_Reportes.dt2 = mtdFilial.Get_DatosFilial();
        F_Reportes.dt3 = DtArticulos;

        F_Reportes.NombreDelReporte = "entrega_cupones.Reportes.Rpt_OrdenReservaQuincho.rdlc"; //_NroCupon == 0 ? "rpt_CuponDDNiñoExepcion" : "rpt_CuponDDNiño";
        F_Reportes.ShowDialog();

      }
    }

    private void txt_CantInvitados_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
      {
        e.Handled = true;
      }
    }



    private void Txt_LavadoVajilla_TextChanged(object sender, EventArgs e)
    {
      Sumar();
    }

    private void Sumar()
    {
      decimal LavadoVajilla = string.IsNullOrEmpty(Txt_LavadoVajilla.Text) ? 0 : Convert.ToDecimal(Txt_LavadoVajilla.Text);
      decimal LimpizaQuincho = string.IsNullOrEmpty(Txt_LimpiezaQuincho.Text) ? 0 : Convert.ToDecimal(Txt_LimpiezaQuincho.Text);

      Txt_Total.Text = (LavadoVajilla + LimpizaQuincho).ToString();
    }

    private void Txt_LavadoVajilla_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
      {
        e.Handled = true;
      }

      //solo 1 punto decimal
      if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
      {
        e.Handled = true;
      }
    }

    private void Txt_LimpiezaQuincho_TextChanged(object sender, EventArgs e)
    {
      Sumar();
    }

    private void Txt_Total_TextChanged(object sender, EventArgs e)
    {

    }

    private void Txt_LimpiezaQuincho_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
      {
        e.Handled = true;
      }

      //solo 1 punto decimal
      if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
      {
        e.Handled = true;
      }
    }

    private void Btn_EmitirRecibo_Click(object sender, EventArgs e)
    {

      using (var context = new lts_sindicatoDataContext())
      {
        _NroAutomatico = MtdReservasQuinchos.GetLastNroRecibo() + 1;
        Recibos Recibo = new Recibos
        {
          NroAutomatico = _NroAutomatico,
          NroReservaQuincho = Convert.ToInt32(Txt_NroAutorizacion.Text),
          FechaAutomatica = DateTime.Now,
          Importe = Convert.ToDecimal(Txt_Total.Text),
          UsuarioId = _UsuarioId,
          Estado = 1
        };
        context.Recibos.InsertOnSubmit(Recibo);
        context.SubmitChanges();
        ImprimirRecibo();
        btn_ImprimirReserva.Enabled = true;
        Btn_EmitirRecibo.Enabled = false;
      }

    }

    private void ImprimirRecibo()
    {
      DS_cupones ds = new DS_cupones();

      DataTable dt = ds.ReciboDeCobro;
      dt.Clear();
      DataRow dr = dt.NewRow();

      dr["Fecha"] = dtp_consulta.Value;
      dr["Numero"] = _NroAutomatico;
      dr["Importe"] = Txt_Total.Text;
      dr["De"] = txt_Nombre.Text.Trim() + " - " + "Socio N° " + txt_NroSocio.Text.Trim();
      dr["ImporteEnLetras"] = mtdNum2words.enletras(Txt_Total.Text);
      dr["Concepto"] = "Seguro de Vajilla $" + Txt_LavadoVajilla.Text + " y Limpieza de quincho $" + Txt_LimpiezaQuincho.Text + " para la reserva N° " + Txt_NroAutorizacion.Text;
      dr["Usuario"] = _UsuarioName;
      dr["NroAutorizacionQuincho"] = Txt_NroAutorizacion.Text;

      dt.Rows.Add(dr);

      reportes F_Reportes = new reportes();
      F_Reportes.dt = dt;
      F_Reportes.dt2 = mtdFilial.Get_DatosFilial();

      F_Reportes.NombreDelReporte = "entrega_cupones.Reportes.Rpt_ReciboDeCobro.rdlc";
      F_Reportes.ShowDialog();
    }

  }
}
