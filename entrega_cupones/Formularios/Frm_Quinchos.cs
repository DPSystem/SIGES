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
  public partial class Frm_Quinchos : Form
  {
    public string Nombre;

    public Frm_Quinchos()
    {
      InitializeComponent();
    }

    private void Frm_Quinchos_Load(object sender, EventArgs e)
    {

    }

    private void Btn_BuscarSocio_Click(object sender, EventArgs e)
    {
      Frm_BuscarSocio F_BuscarSocio = new Frm_BuscarSocio();
      AddOwnedForm(F_BuscarSocio);
      F_BuscarSocio.ShowDialog();
    }

    private void Btn_Siguiente_Click(object sender, EventArgs e)
    {
      Pnl_Paso2.Enabled = true;

    }
  }
}
