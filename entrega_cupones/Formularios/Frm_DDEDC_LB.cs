using entrega_cupones.Clases;
using entrega_cupones.Metodos;
using entrega_cupones.Modelos;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace entrega_cupones.Formularios
{
  public partial class Frm_DDEDC_LB : Form
  {
    public bool _EsSocio;
    public int _NroSocio = 0;
    public double _Cuil = 0;
    public DateTime _FechaNac = DateTime.Now;
    public string _Edad;
    public int _UsuarioId = 0;
    public string _UsuarioNombre;
    public int _Reimprimir = 0;
    public bool _CuponEmitido = false;
    public int _EventoId = 0;
    public int _EventoAñoId = 0;
    public int _NroCupon = 0;
    public int _Acompañante = 0;
    public int _AcompañantePredio = 0;
    public int _InvitacionEspecial = 0;
    public int _CostoEntrada = 0;
    public Image _FotoOriginal;
    List<MdlCuponesEmitidos> _CuponesEmitidosList = new List<MdlCuponesEmitidos>();

    public Frm_DDEDC_LB()
    {
      InitializeComponent();
    }

    private void frm_DDLM_Load(object sender, EventArgs e)
    {
      if (_CuponEmitido)
      {
        btn_GenerarCupon.Enabled = false;
        btn_ReimprimirBOTE.Enabled = true;
        _Reimprimir = 1;
      }

      if (_EsSocio)
      {
        btn_GenerarCupon.Enabled = true;
        Btn_EntradaPredio.Enabled = true;

      }
      else
      {
        btn_GenerarCupon.Enabled = false;
        Btn_EntradaPredio.Enabled = false;

      }
      dgv_CuponesEmitidos.AutoGenerateColumns = false; 
      Dgv_CajaPorUsuario.AutoGenerateColumns = false;
      Cbx_Filtro.SelectedIndex = 0;
      //CargarCuponesEntregados();
      //CalcularTotales();

    }
    private void CalcularTotales()
    {
      txt_TotalCupones.Text = dgv_CuponesEmitidos.RowCount.ToString();
      txt_TotalSocios.Text = dgv_CuponesEmitidos.Rows.Cast<DataGridViewRow>().Count(row => row.Cells["Invitado"].Value.ToString() == "0").ToString();
      txt_TotalNOSocios.Text = dgv_CuponesEmitidos.Rows.Cast<DataGridViewRow>().Count(row => row.Cells["Invitado"].Value.ToString() == "1").ToString();
      Txt_TotalCaja.Text = (dgv_CuponesEmitidos.Rows.Cast<DataGridViewRow>().Count(row => row.Cells["Invitado"].Value.ToString() == "1") * 500).ToString();
    }

    private void CargarCuponesEntregados()
    {
      _CuponesEmitidosList.Clear();
      _CuponesEmitidosList.AddRange(MtdEventos.GetCuponesEmitidos_(4, Cbx_Filtro.SelectedIndex, Dtp_Fecha.Value));


      var CE3 = from a in _CuponesEmitidosList
                group a by new { a.UsuarioId, a.UsuarioNombre } into Grupo
                select new
                {
                  UsuarioNombre = Grupo.Key.UsuarioNombre,
                  EntradaSocio = Grupo.Count(x => x.Invitado == 0),
                  EntradaInvitado = Grupo.Count(x => x.Invitado == 1),
                  Caja = Grupo.Count(x => x.Invitado == 1) * 500,
                };

      dgv_CuponesEmitidos.DataSource = _CuponesEmitidosList.ToList();
      Dgv_CajaPorUsuario.DataSource = CE3.ToList();
    }

    private void btn_GenerarCupon_Click(object sender, EventArgs e)
    {
      _EventoAñoId = 4;
      _Acompañante = 0;
      if (_NroSocio == 0)
      {
        if (MessageBox.Show("NO ES UN SOCIO ACTIVO - ESTA SEGURO DE EMITIR EL CUPON ???  ", "¡¡¡ ATENCION !!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
          EmitirCupon();
        }
      }
      else
      {
        EmitirCupon();
      }
      CargarCuponesEntregados();
      CalcularTotales();
    }

    private void EmitirCupon()
    {
      _NroCupon = MtdEventos.GetCuponGeneradoDDEDC(_EventoAñoId, Convert.ToString(_Cuil));
      if (_Reimprimir == 0)
      {

        if (_NroCupon == 0)
        {
          SetCuponDDEDC();

          if (_EventoAñoId == 4)
          {
            ImprimirCuponPredio();
          }
          else
          {
            ImprimirCupon();
          }

        }
        else
        {
          MessageBox.Show("El Cupon del Socio ya fue Emitido, no Puede Emitir 2 Veces. Debe Reimprimir el Cupon.", "ATENCION");
          btn_ReimprimirBOTE.Enabled = true;
          btn_ReimprimirBOTE.Focus();
        }
      }
      else
      {
        ImprimirCuponPredio();
      }
    }


    private void SetCuponDDEDC()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        _NroCupon = MtdEventos.GetUltimoNroDeCupon(_EventoAñoId) + 1;

        EventosCupones_ ec = new EventosCupones_();
        ec.FechaGeneracion = DateTime.Now;
        ec.EventoId = _EventoId;
        ec.EventoAnioId = _EventoAñoId;
        ec.NroCupon = _NroCupon;
        ec.CuilTitular = _Cuil.ToString();
        ec.CodigoFamiliar = "0";
        ec.DniFamiliar = "0";
        ec.UsuarioId = _UsuarioId;
        ec.Estado = 1;
        ec.Exepcion = 0;
        ec.Invitado = _Acompañante;
        ec.InvitacionEspecial = _InvitacionEspecial;
        ec.Costo = _Acompañante == 1 ? (decimal)(from a in context.EventosAño where a.Id == _EventoAñoId select a).FirstOrDefault().CostoDeEntrada : 0;
        context.EventosCupones_.InsertOnSubmit(ec);
        context.SubmitChanges();

      }
    }


    private void ImprimirCupon()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        try
        {
          //Como el reporte es en Forma Vertical se Gira la Imagen que se pasa al DataTable

          Bitmap Foto = (Bitmap)picbox_socio.Image;
          Bitmap Logo = (Bitmap)Image.FromFile("C:\\SEC_Gestion\\Imagen\\Logo_reporte.jpg");
          Bitmap Logo2 = (Bitmap)Image.FromFile("C:\\SEC_Gestion\\Imagen\\Logo2.jpg");
          Bitmap Logo3 = (Bitmap)Image.FromFile("C:\\SEC_Gestion\\Imagen\\Logo3.jpg");
          Bitmap Logo4 = (Bitmap)Image.FromFile("C:\\SEC_Gestion\\Imagen\\Logo4.jpg");

          if (_Acompañante == 0)
          {
            Foto.RotateFlip(RotateFlipType.Rotate270FlipNone);
            Logo.RotateFlip(RotateFlipType.Rotate270FlipNone);
            Logo2.RotateFlip(RotateFlipType.Rotate270FlipNone);
            Logo3.RotateFlip(RotateFlipType.Rotate270FlipNone);
          }

          var EventAño = (from a in context.EventosAño where a.Id == _EventoAñoId select a).FirstOrDefault();
          string R = _Reimprimir == 1 ? " - R" : "";
          reportes frm_reportes = new reportes();
          DS_cupones ds = new DS_cupones();

          DataTable dt = ds.DDEDC_Entrada;
          dt.Clear();
          DataRow dr2 = dt.NewRow();
          dr2["titu_apenom"] = txt_Nombre.Text;
          dr2["titu_dni"] = txt_Dni.Text;
          dr2["titu_empresa"] = txt_Empresa.Text;
          dr2["titu_nrosocio"] = _NroSocio;
          dr2["titu_edad"] = _Edad;
          dr2["Logo"] = mtdConvertirImagen.ImageToByteArray(Logo);
          dr2["Logo2"] = mtdConvertirImagen.ImageToByteArray(Logo2);
          dr2["Logo3"] = mtdConvertirImagen.ImageToByteArray(Logo3);
          dr2["Logo4"] = mtdConvertirImagen.ImageToByteArray(Logo4);
          dr2["titu_foto"] = mtdConvertirImagen.ImageToByteArray(Foto);//mtdConvertirImagen.ImageToByteArray( Picbox_Beneficiario.Image);
          dr2["event_nrocupon"] = _NroCupon;
          dr2["reimpresion"] = _Reimprimir;

          if (_NroCupon == 0)
          {
            dr2["Linea1"] = "INVITADO" + R;
            dr2["Linea2"] = "↑ ↑ ↑ NO VALIDO PARA SORTEO ↑ ↑ ↑";
            dr2["Linea4"] = "DIA DEL EMPLEADO DE COMERCIO " + EventAño.Año.ToString() + R;
          }
          else
          {
            dr2["Linea1"] = "CUPON SORTEO N° " + _NroCupon.ToString() + R;
            dr2["Linea2"] = "↑ ↑ ↑ CUPON PARA LA URNA ↑ ↑ ↑";
            dr2["Linea4"] = "CUPON SORTEO N° " + _NroCupon.ToString() + R;
          }

          dr2["Linea3"] = "↓ ↓ ↓ CUPON PARA EL SOCIO ↓ ↓ ↓";
          dr2["Linea5"] = EventAño.Linea5;
          dr2["Linea6"] = EventAño.Liena6;
          dr2["Linea7"] = EventAño.Linea7;
          dr2["Linea8"] = EventAño.Linea8;
          dr2["Linea9"] = EventAño.Linea9;
          dr2["Linea10"] = EventAño.Linea10;
          dr2["Linea11"] = EventAño.Linea11;
          dr2["Linea12"] = EventAño.Linea12;
          dr2["Usuario"] = _UsuarioNombre;
          dr2["Costo"] = EventAño.CostoDeEntrada;

          dt.Rows.Add(dr2);
          if (_EventoAñoId == 4 && _Acompañante == 0)
          {
            Foto.RotateFlip(RotateFlipType.Rotate90FlipNone);
            picbox_socio.Image = Foto;
          }


          try
          {   //Instanciamos un LocalReport, le indicamos el report a imprimir y le cargamos los datos
            LocalReport rdlc = new LocalReport();

            if (_Acompañante == 0)
            {
              rdlc.ReportEmbeddedResource = "entrega_cupones.Reportes.Rpt_DDEDC_Entrada.rdlc";
            }
            else
            {
              rdlc.ReportEmbeddedResource = "entrega_cupones.Reportes.Rpt_DDEDC_Entrada_Acomp.rdlc";
            }
            rdlc.DataSources.Add(new ReportDataSource("DataSet1", dt));
            rdlc.DataSources.Add(new ReportDataSource("DataSet2", mtdFilial.Get_DatosFilial()));
            //Imprime el report
            Impresor imp = new entrega_cupones.Impresor();

            imp.Imprime(rdlc);
          }
          catch (Exception ex)
          {
            MessageBox.Show(ex.Message);
          }


          //frm_reportes.dt = dt;
          //frm_reportes.dt2 = mtdFilial.Get_DatosFilial();

          //frm_reportes.NombreDelReporte = "entrega_cupones.Reportes.Rpt_DDEDC_Entrada.rdlc"; //_NroCupon == 0 ? "rpt_CuponDDNiñoExepcion" : "rpt_CuponDDNiño";
          //frm_reportes.Show();

        }
        catch (Exception)
        {
          throw;
        }
      }
    }

    private void ImprimirCuponPredio()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        try
        {
          //Como el reporte es en Forma Vertical se Gira la Imagen que se pasa al DataTable

          Bitmap Foto = (Bitmap)picbox_socio.Image;
          Bitmap Logo = (Bitmap)Image.FromFile("C:\\SEC_Gestion\\Imagen\\Logo_reporte.jpg");
          Bitmap Logo2 = (Bitmap)Image.FromFile("C:\\SEC_Gestion\\Imagen\\Logo2.jpg");
          Bitmap Logo3 = (Bitmap)Image.FromFile("C:\\SEC_Gestion\\Imagen\\Logo3.jpg");
          Bitmap Logo4 = (Bitmap)Image.FromFile("C:\\SEC_Gestion\\Imagen\\Logo4.jpg");


          var EventAño = (from a in context.EventosAño where a.Id == _EventoAñoId select a).FirstOrDefault();
          string R = _Reimprimir == 1 ? " - R" : "";
          //reportes frm_reportes = new reportes();
          DS_cupones ds = new DS_cupones();

          DataTable dt = ds.DDEDC_Entrada;
          dt.Clear();
          DataRow dr2 = dt.NewRow();
          dr2["titu_apenom"] = txt_Nombre.Text;
          dr2["titu_dni"] = txt_Dni.Text;
          dr2["titu_empresa"] = txt_Empresa.Text;
          dr2["titu_nrosocio"] = _NroSocio;
          dr2["titu_edad"] = _Edad;
          dr2["Logo"] = mtdConvertirImagen.ImageToByteArray(Logo);
          dr2["Logo2"] = mtdConvertirImagen.ImageToByteArray(Logo2);
          dr2["Logo3"] = mtdConvertirImagen.ImageToByteArray(Logo3);
          dr2["Logo4"] = mtdConvertirImagen.ImageToByteArray(Logo4);
          dr2["titu_foto"] = mtdConvertirImagen.ImageToByteArray(picbox_socio.Image);//mtdConvertirImagen.ImageToByteArray( Picbox_Beneficiario.Image);
          dr2["event_nrocupon"] = _NroCupon;
          dr2["reimpresion"] = _Reimprimir;

          if (_NroCupon == 0)
          {
            dr2["Linea1"] = "INVITADO" + R;
            dr2["Linea2"] = "↑ ↑ ↑ NO VALIDO PARA SORTEO ↑ ↑ ↑";
            dr2["Linea4"] = "DIA DEL EMPLEADO DE COMERCIO " + EventAño.Año.ToString() + R;
          }
          else
          {
            dr2["Linea1"] = "CUPON SORTEO N° " + _NroCupon.ToString() + R;
            dr2["Linea2"] = "↑ ↑ ↑ CUPON PARA LA URNA ↑ ↑ ↑";
            dr2["Linea4"] = "CUPON SORTEO N° " + _NroCupon.ToString() + R;
          }

          dr2["Linea3"] = "↓ ↓ ↓ CUPON PARA EL SOCIO ↓ ↓ ↓";
          dr2["Linea5"] = EventAño.Linea5;
          dr2["Linea6"] = EventAño.Liena6;
          dr2["Linea7"] = EventAño.Linea7;
          dr2["Linea8"] = EventAño.Linea8;
          dr2["Linea9"] = EventAño.Linea9;
          dr2["Linea10"] = EventAño.Linea10;
          dr2["Linea11"] = EventAño.Linea11;
          dr2["Linea12"] = EventAño.Linea12;
          dr2["Usuario"] = _UsuarioNombre;

          dt.Rows.Add(dr2);
          //picbox_socio.Image = _FotoOriginal;

          try
          {   //Instanciamos un LocalReport, le indicamos el report a imprimir y le cargamos los datos

            LocalReport rdlc = new LocalReport();

            if (_AcompañantePredio == 0)
            {
              rdlc.ReportEmbeddedResource = "entrega_cupones.Reportes.Rpt_DDEDC_Entrada_Bizza.rdlc";
            }
            else
            {
              rdlc.ReportEmbeddedResource = "entrega_cupones.Reportes.Rpt_DDEDC_Entrada_Bizza_Anticip.rdlc";
            }

            rdlc.DataSources.Add(new ReportDataSource("DataSet1", dt));
            rdlc.DataSources.Add(new ReportDataSource("DataSet2", mtdFilial.Get_DatosFilial()));
            //Imprime el report
            Impresor imp = new entrega_cupones.Impresor();

            imp.Imprime(rdlc);
          }
          catch (Exception ex)
          {
            MessageBox.Show(ex.Message);
          }


          //frm_reportes.dt = dt;
          //frm_reportes.dt2 = mtdFilial.Get_DatosFilial();

          //frm_reportes.NombreDelReporte = "entrega_cupones.Reportes.Rpt_DDEDC_Entrada.rdlc"; //_NroCupon == 0 ? "rpt_CuponDDNiñoExepcion" : "rpt_CuponDDNiño";
          //frm_reportes.Show();

        }
        catch (Exception)
        {
          throw;
        }
      }
    }

    private void btn_Salir_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void btn_Reimprimir_Click(object sender, EventArgs e)
    {
      _Reimprimir = 1;
      _Acompañante = 0;
      _EventoAñoId = 4;
      EmitirCupon();
      _Reimprimir = 0;
      _NroCupon = 0;
    }

    private void Btn_AcompañanteBOTE_Click(object sender, EventArgs e)
    {
      for (int i = 1; i <= Convert.ToInt32(Txt_CantBote.Text); i++)
      {
        _Acompañante = 1;
        _AcompañantePredio = 1;
        _EventoAñoId = 4;
        ImprimirCuponAcompañante();
      }
      Txt_CantBote.Text = "1";

    }

    private void ImprimirCuponAcompañante()
    {
      SetCuponDDEDC();
      //ImprimirCupon();
      ImprimirCuponPredio();
    }

    private void Btn_EntradaPredio_Click(object sender, EventArgs e)
    {
      _AcompañantePredio = 0;
      _Acompañante = 0;
      _EventoAñoId = 5;
      EmitirCupon();

    }

    private void Btn_AcompañantePredio_Click(object sender, EventArgs e)
    {
      for (int i = 1; i <= Convert.ToInt32(Txt_CantPredio.Text); i++)
      {
        _AcompañantePredio = 1;
        _Acompañante = 1;
        _EventoAñoId = 5;
        SetCuponDDEDC();
        ImprimirCuponPredio();
      }
      Txt_CantPredio.Text = "1";
    }


    private void Btn_InvitacionEspecialBOTE_Click(object sender, EventArgs e)
    {
      _EventoAñoId = 4;

    }

    private void Btn_ReimprimirPredio_Click(object sender, EventArgs e)
    {
      _EventoAñoId = 5;
    }

    private void Btn_InvitacionEspecialPredio_Click(object sender, EventArgs e)
    {
      _EventoAñoId = 5;
    }

    private void Cbx_Filtro_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (Cbx_Filtro.SelectedIndex == 0)
      {
        Dtp_Fecha.Visible = false;
        CargarCuponesEntregados();
        CalcularTotales();
      }
      else
      {
        Dtp_Fecha.Visible = true;
        CargarCuponesEntregados();
        CalcularTotales();
      }
    }

    private void Dtp_Fecha_ValueChanged(object sender, EventArgs e)
    {
      CargarCuponesEntregados();
      CalcularTotales();
    }
  }
}
