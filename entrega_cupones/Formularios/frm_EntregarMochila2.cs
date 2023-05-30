using entrega_cupones.Metodos;
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
  public partial class frm_EntregarMochila2 : Form
  {
    public frm_EntregarMochila2()
    {
      InitializeComponent();
    }

    private void frm_EntregarMochila2_Load(object sender, EventArgs e)
    {
      dgv_CuponesEmitidos.AutoGenerateColumns = false;
      dgv_ControlDeStock.AutoGenerateColumns = false;
      dgv_ControlDeStock.DataSource = MtdMochilas.GetControlStock();
      dgv_CuponesEmitidos.DataSource = MtdMochilas.GetCuponesEmitidos(5);
      PintarEntregados();
      CalcularTotales();
    }

    private void PintarEntregados()
    {
      foreach (DataGridViewRow fila in dgv_CuponesEmitidos.Rows)
      {
        if (fila.Cells["FechaEntrega"].Value != null)
        {
          fila.DefaultCellStyle.BackColor = System.Drawing.Color.Green;
        }
      }
    }
    private void CalcularTotales()
    {
      txt_TotalCupones.Text = dgv_CuponesEmitidos.RowCount.ToString();
      txt_TotalEntregados.Text = dgv_CuponesEmitidos.Rows.Cast<DataGridViewRow>().Count(row => row.Cells["FechaEntrega"].Value != null).ToString();
      txt_TotalNoentregados.Text = dgv_CuponesEmitidos.Rows.Cast<DataGridViewRow>().Count(row => row.Cells["FechaEntrega"].Value == null).ToString();
    }

    private void btn_BuscarCupon_Click(object sender, EventArgs e)
    {
      BuscarCupon();
    }

    private void BuscarCupon()
    {
      if (!string.IsNullOrEmpty(txt_NroDeCupon.Text))
      {
        using (var context = new lts_sindicatoDataContext())
        {

          var entregado = from a in context.eventos_cupones where a.event_cupon_nro == Convert.ToInt32(txt_NroDeCupon.Text) && a.eventcupon_evento_id == 5 select new { a.FechaDeEntregaArticulo, a.ArticuloID, a.CuilStr };
          if (entregado.Count() > 0)
          {
            dgv_CuponMochila.DataSource = MtdMochilas.GetCuponMochila(Convert.ToInt32(txt_NroDeCupon.Text));

            var socio = mtdSocios.GetDatosDelSocio(entregado.Single().CuilStr);
            txt_Socio.Text = socio.ApeNom;
            txt_NroSocio.Text = socio.NroDeSocio;

            if (entregado.Single().FechaDeEntregaArticulo != null)
            {
              txt_MochilaEntregada.Text = "ENTREGADO";
              txt_FechaDeEntrega.Text = entregado.Single().FechaDeEntregaArticulo.ToString();
              btn_EntregarMochila.Enabled = false;
            }
            else
            {
              txt_MochilaEntregada.Text = "NO ENTREGADO";
              txt_FechaDeEntrega.Text = "---------";
              btn_EntregarMochila.Enabled = true;
              btn_EntregarMochila.Focus();
            }
          }
          else
          {
            txt_MochilaEntregada.Text = "CUPON NO EXISTE";
            txt_FechaDeEntrega.Text = "---------";
            btn_EntregarMochila.Enabled = false;
          }
        }
      }
    }

    private void btn_EntregarMochila_Click(object sender, EventArgs e)
    {
      using (var datacontext = new lts_sindicatoDataContext())
      {
        var entregado = (from a in datacontext.eventos_cupones where a.event_cupon_nro == Convert.ToInt32(txt_NroDeCupon.Text) && a.eventcupon_evento_id == 5 select a).Single();

        entregado.FechaDeEntregaArticulo = DateTime.Now;
        var cuponBenef = from a in datacontext.CuponBenefArticulos.Where(x => x.NroCupon == Convert.ToInt32(txt_NroDeCupon.Text)) select a;
        if (cuponBenef.Count() > 0)
        {
          cuponBenef.ToList().ForEach(x => x.Estado = 1);
        }

        datacontext.SubmitChanges();
        MessageBox.Show("La Mochila fue entregada con exito !!!", "Entrega de Mochilas");
        txt_FechaDeEntrega.Text = "";
        txt_NroDeCupon.Text = "";
        txt_MochilaEntregada.Text = "";
        txt_NroDeCupon.Focus();
        btn_EntregarMochila.Enabled = false;
        dgv_ControlDeStock.DataSource = MtdMochilas.GetControlStock();
        dgv_CuponesEmitidos.DataSource = MtdMochilas.GetCuponesEmitidos(5);
        PintarEntregados();
        CalcularTotales();

      }
    }

    private void txt_NroDeCupon_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        BuscarCupon();
      }
    }
  }
}
