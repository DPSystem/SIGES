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
  public partial class frm_DDP : Form
  {
    public int _NroSocio = 0;
    public double _Cuil = 0;
    public int _UsuarioID = 0;
    public int _Reimpresion = 0;
    public bool _CuponEmitido = false;
    public int _EventoId = 0;
    public string _DNI = string.Empty;
    public bool _EsSocio = false;

    public frm_DDP()
    {
      InitializeComponent();
    }

    private void frm_DDP_Load(object sender, EventArgs e)
    {
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
      dgv_CuponesEmitidos.DataSource = MtdEventos.GetCuponesEmitidos(10);
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

      int NroDECupon = 0;

      if (_Reimpresion == 0)
      {
        NroDECupon = GetNroDeCupon();
      }
      else
      {
        NroDECupon = MtdEventos.GetNroCuponEmitido(10, _Cuil.ToString());
      }

      MtdSorteos.ImprimirCuponSorteo(NroDECupon, _Cuil.ToString(), txt_Nombre.Text, _DNI, txt_Empresa.Text, _NroSocio.ToString(), mtdConvertirImagen.ImageToByteArray(picbox_socio.Image), _Reimpresion.ToString(), "rpt_CuponSorteoDDP");
     
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
            insert.event_cupon_nro = context.eventos_cupones.Where(x => x.eventcupon_evento_id == _EventoId).Max(x => x.event_cupon_nro) + 1;
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
        insert.eventcupon_evento_id = 10;
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
