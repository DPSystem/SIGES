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

namespace entrega_cupones.Formularios.Tesoreria
{
  public partial class Frm_PagoAProv : Form
  {
    List<MdlOPIVistaPrevia> _OPIVistaPrevia = new List<MdlOPIVistaPrevia>();
    public Frm_PagoAProv()
    {
      InitializeComponent();
    }

    private void Frm_PagoAProv_Load(object sender, EventArgs e)
    {
      CargarCbxProveedores();
      CargarCuentas();
      CargarCbxComprobantes();
      CargarCbxComprobantesLetra();
      CargarOPI();
      CargarCbx_Bancos();
      Txt_OrdenPago.Focus();
    }

    private void CargarCbxProveedores()
    {
      Cbx_Proveedor.DisplayMember = "Nombre";
      Cbx_Proveedor.ValueMember = "Id";
      Cbx_Proveedor.DataSource = MtdProveedores.GetProveedores();

    }

    private void CargarCuentas()
    {
      Cbx_Imputacion.DisplayMember = "Nombre";
      Cbx_Imputacion.ValueMember = "Id";
      Cbx_Imputacion.DataSource = MtdCuentas.GetCuentas();
    }

    private void CargarCbxComprobantes()
    {
      Cbx_TipoComprobantes.DisplayMember = "Nombre";
      Cbx_TipoComprobantes.ValueMember = "Id";
      Cbx_TipoComprobantes.DataSource = MtdTipoComprobante.GetComprobantes();
    }

    private void CargarCbxComprobantesLetra()
    {
      Cbx_LetraComprobante.DisplayMember = "Nombre";
      Cbx_LetraComprobante.ValueMember = "Id";
      Cbx_LetraComprobante.DataSource = MtdComprobanteLetra.GetLetraComprobantes();
    }

    private void CargarOPI()
    {
      Txt_OrdenPago.Text = MtdOPI.GetNroOP().ToString();
      Txt_OrdenIngreso.Text = MtdOPI.GetNroOP().ToString();
    }

    private void CargarCbx_Bancos()
    {
      Cbx_BancoTransf.DisplayMember = "Nombre";
      Cbx_BancoTransf.ValueMember = "Id";
      Cbx_BancoTransf.DataSource = MtdBancos.GetBancos();

      Cbx_BancosCheques.DisplayMember = "Nombre";
      Cbx_BancosCheques.ValueMember = "Id";
      Cbx_BancosCheques.DataSource = MtdBancos.GetBancos();

    }

    private void Txt_OrdenPago_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        Cbx_Proveedor.Focus();
        Cbx_Proveedor.DroppedDown = true;
        // SendKeys.Send("{ENTER}");
      }
    }

    private void Cbx_Proveedor_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        Cbx_Imputacion.Focus();
        Cbx_Imputacion.DroppedDown = true;
      }
    }

    private void Cbx_Imputacion_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        Cbx_TipoComprobantes.Focus();
        Cbx_TipoComprobantes.DroppedDown = true;
      }
    }

    private void Cbx_TipoComprobantes_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        Cbx_LetraComprobante.Focus();
        Cbx_LetraComprobante.DroppedDown = true;
      }
    }

    private void Cbx_LetraComprobante_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        Txt_ComprobanteNro.Focus();

      }
    }

    private void Txt_ComprobanteNro_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        Txt_ComprobanteImporte.Focus();

      }
    }

    private void Txt_ComprobanteImporte_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        Txt_ComprobanteComentario.Focus();

      }
    }

    private void Txt_ComprobanteComentario_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        Txt_Efectivo.Focus();
      }
    }

    private void Cbx_BancosCheques_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        Txt_ChequeNro.Focus();
      }
    }

    private void Txt_ChequeNro_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        Msk_FechaEmisionCheque.Focus();
      }
    }

    private void Msk_FechaEmisionCheque_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        Msk_FechaCobroCheque.Focus();
      }
    }

    private void Msk_FechaCobroCheque_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        Btn_CargarCheque.Focus();
      }
    }

    private void Cbx_BancoTransf_KeyDown(object sender, KeyEventArgs e)
    {

      if (e.KeyCode == Keys.Enter)
      {
        msk_FechaTrasf.Focus();
      }
    }

    private void msk_FechaTrasf_KeyDown(object sender, KeyEventArgs e)
    {

      if (e.KeyCode == Keys.Enter)
      {
        txt_NroTransf.Focus();
      }
    }

    private void txt_NroTransf_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        txt_MontoTransf.Focus();
      }
    }

    private void txt_MontoTransf_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        Btn_CargarTrasf.Focus();
      }
    }

    private void Btn_CargarEfectivo_Click(object sender, EventArgs e)
    {
      CargarPagoEnEfectivo();
    }

    private void Btn_CancelarEfectivo_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Esta Seguro de Cancelar el Pago en Efectivo?", "ATENCION !!!! ", MessageBoxButtons.OKCancel) == DialogResult.OK)
      {
        MessageBox.Show("Pago En Efectivo Cancelado");
        Txt_Efectivo.Text = "";
      }
    }

    private void CargarPagoEnEfectivo()
    {
      
    }

  }
}
