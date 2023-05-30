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
  public partial class Frm_Asientos : Form
  {
    public Frm_Asientos()
    {
      InitializeComponent();
    }

    private void Frm_Asientos_Load(object sender, EventArgs e)
    {
      cbx_TipoAsiento.SelectedIndex = 0;
      Cbx_Imputacion.SelectedIndex = 0;
      Cbx_MedioDePago.SelectedIndex = 0;
      Cbx_TipoComprobante.SelectedIndex = 0;
      // Prueba de GitHub
    }

    private void Btn_Salir_Click(object sender, EventArgs e)
    {
      Close();
    }
  }
}
