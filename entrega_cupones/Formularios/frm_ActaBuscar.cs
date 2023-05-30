using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using entrega_cupones.Metodos;
using entrega_cupones.Modelos;

namespace entrega_cupones.Formularios
{
  public partial class frm_ActaBuscar : Form
  {
    public frm_ActaBuscar()
    {
      InitializeComponent();
    }

    private void frm_ActaBuscar_Load(object sender, EventArgs e)
    {
      //mtdActas.Get_ListadoDeActas();
      dgv_Actas.AutoGenerateColumns = false;
      dgv_Actas.DataSource = mtdActas.Get_ListadoDeActas();
      MarcarAnuladas();
    }

    private void MarcarAnuladas()
    {
      foreach (DataGridViewRow fila in dgv_Actas.Rows)
      {
        if (fila.Cells["Estado"].Value.ToString() == "1")
        {
          fila.Cells["EstadoMostrar"].Value = "ANULADA";
          fila.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
        }
        if (fila.Cells["Estado"].Value.ToString() == "0")
        {
          fila.Cells["EstadoMostrar"].Value = "ACTIVA";
          //fila.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
        }
      }
    }

    private void btn_VerVD_Click(object sender, EventArgs e)
    {
      var NroActa = dgv_Actas.CurrentRow.Cells["NroActa"].Value;
      mtdActas.ReimprimirActa(Convert.ToInt32(NroActa));
    }

    private void btn_Salir_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void btn_AnularActa_Click(object sender, EventArgs e)
    {

      string NroActa = dgv_Actas.CurrentRow.Cells["NroActa"].Value.ToString();

      if (!mtdActas.VerificarSiEstaAnulada(Convert.ToInt32(NroActa)))
      {
        if (MessageBox.Show("Esta Seguro de '' ANULAR '' el Acta Nº  " + NroActa + "  ????", "¡¡¡ ATENCION !!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
          mtdActas.AnularActa(Convert.ToInt32(NroActa));
          dgv_Actas.DataSource = mtdActas.Get_ListadoDeActas();
          MarcarAnuladas();
        }
      }
      else
      {
        MessageBox.Show("El Acta Nº  " + NroActa + " Ya se Encuentra Anulada", "¡¡¡ ATENCION !!!");
      }
    }
  }
}
