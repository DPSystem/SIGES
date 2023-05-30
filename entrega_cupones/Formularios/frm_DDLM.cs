using entrega_cupones.Clases;
using entrega_cupones.Metodos;
using entrega_cupones.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entrega_cupones.Formularios
{
  public partial class frm_DDLM : Form
  {
    public int _NroSocio = 0;
    public double _Cuil = 0;
    public int _UsuarioID = 0;
    public int _Reimpresion = 0;
    public bool _CuponEmitido = false;
    public int _EventoId = 0;

    public frm_DDLM()
    {
      InitializeComponent();
    }

    private void frm_DDLM_Load(object sender, EventArgs e)
    {
      dgv_CuponesEmitidos.AutoGenerateColumns = false;
      if (_CuponEmitido)
      {
        btn_GenerarCupon.Enabled = false;
        btn_Reimprimir.Enabled = true;
        _Reimpresion = 1;

      }

      CargarCuponesEntregados();
      CalcularTotales();

      }
    private void CalcularTotales()
    {
      txt_TotalCupones.Text = dgv_CuponesEmitidos.RowCount.ToString();
      txt_TotalSocios.Text = dgv_CuponesEmitidos.Rows.Cast<DataGridViewRow>().Count(row => row.Cells["NroCupon"].Value.ToString() != "0").ToString();
      txt_TotalNOSocios.Text = dgv_CuponesEmitidos.Rows.Cast<DataGridViewRow>().Count(row => row.Cells["NroCupon"].Value.ToString() == "0").ToString();
    }

    private void CargarCuponesEntregados()
    {
      dgv_CuponesEmitidos.DataSource = MtdEventos.GetCuponesEmitidos(3);
    }

    private void btn_GenerarCupon_Click(object sender, EventArgs e)
    {
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
    }

    private void EmitirCupon()
    {

      MdlFilial DatosFilial = mtdFilial.Get_DatosFilial2().FirstOrDefault();

      usuarios usr = new usuarios();
      reportes frm_reportes = new reportes();
      DS_cupones ds = new DS_cupones();
      int NroDECupon = 0;

      if (_Reimpresion == 0)
      {
        NroDECupon = GetNroDeCupon();
      }
      else
      {
        NroDECupon = MtdEventos.GetNroCuponEmitido(3, _Cuil.ToString());
      }

      DataTable dt = ds.Eventos;
      dt.Clear();
      DataRow dr2 = dt.NewRow();
      dr2["Nombre"] = txt_Nombre.Text;
      dr2["DNI"] = txt_Dni.Text;
      dr2["Empresa"] = txt_Empresa.Text;
      dr2["Nrosocio"] = txt_NroSocio.Text;
      dr2["NroEntrada"] = NroDECupon == 0 ? "INVITADA" :  NroDECupon.ToString(); //_NroSocio == 0 ? "INVITADA" : "N°: " + GetNroDeCupon().ToString();
      dr2["EsInvitado"] = _NroSocio == 0 ? 1 : 0;
      dr2["FotoSocio"] = mtdSocios.get_foto_titular_binary(_Cuil).ToArray();
      dr2["ImagenEvento"] = mtdConvertirImagen.ImageToByteArray(Image.FromFile("C:\\SEC_Gestion\\Imagen\\DDLMujer.jpg"));
      dr2["Reimpresion"] = _Reimpresion.ToString();
      dt.Rows.Add(dr2);

      frm_reportes.NombreDelReporte = "entrega_cupones.Reportes.rpt_EntradaDiaDeLaMujer2.rdlc";

      frm_reportes.dt = dt;
      frm_reportes.dt2 = mtdFilial.Get_DatosFilial();
      frm_reportes.dt3 = MtdEventos.Get_EventoAñoDt(3);
      frm_reportes.Show();
      btn_GenerarCupon.Enabled = false;
      btn_Reimprimir.Enabled = true;
      _Reimpresion = 1;
    }

    private int GetNroDeCupon()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        eventos_cupones insert = new eventos_cupones();

        if (_NroSocio > 0) // controlo si es socio para generar el numero de cupon.
        {
          if (context.eventos_cupones.Where(x => x.eventcupon_evento_id == _EventoId).Count() > 0)
          {
            insert.event_cupon_nro = context.eventos_cupones.Where(x=>x.eventcupon_evento_id == _EventoId).Max(x => x.event_cupon_nro) + 1;
          }
          else
          {
            insert.event_cupon_nro = 1;
          }
          insert.Invitado = 0;
        }
        else // si no es socio, entonces es invitado
        {
          insert.event_cupon_nro = 0;
          insert.Invitado = 1;
        }


        //insert.TurnoId = GetTurno(cuilSocio, Termas);
        insert.eventcupon_evento_id = 3;
        insert.eventcupon_maesoc_cuil = _Cuil;
        insert.eventcupon_maeflia_codfliar = 0;
        //insert.Invitado = 0;
        //insert.event_cupon_event_exep_id = ExepcionID;
        insert.event_cupon_fecha = DateTime.Now;
        insert.UsuarioId = _UsuarioID;
        insert.ArticuloID = 0;
        insert.QuienRetiraCupon = "";
        //insert.FondoDeDesempleo = FondoDeDesempleo;
        insert.CuilStr = _Cuil.ToString();

        context.eventos_cupones.InsertOnSubmit(insert);
        context.SubmitChanges();
        return insert.event_cupon_nro;
      }
    }

    private void btn_Salir_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void btn_Reimprimir_Click(object sender, EventArgs e)
    {
      EmitirCupon();
    }
  }
}
