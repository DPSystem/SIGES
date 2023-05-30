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
  public partial class frm_VDBuscar : Form
  {
    public List<mdlVDInspector> _VD_Inspector = new List<mdlVDInspector>();

    public int _UsuarioId;
    public string _Usuario;

    public frm_VDBuscar()
    {
      InitializeComponent();
    }

    private void frm_VDBuscar_Load(object sender, EventArgs e)
    {
      dgv_VD.AutoGenerateColumns = false;
      Get_VDListado();
    }

    public void Get_VDListado()
    {
      dgv_VD.DataSource = _VD_Inspector = mtdVDInspector.Get_VDListado();
    }

    private void btn_VerVD_Click(object sender, EventArgs e)
    {
      VD_Ver();
    }

    public void VD_Ver()
    {
      var VD = _VD_Inspector.Where( x => x.Id == (int)dgv_VD.CurrentRow.Cells["Id"].Value).Single();

      frm_VerVD f_VerVD = new frm_VerVD();
      f_VerVD._VDId = VD.Id;
      f_VerVD._NumeroVD = VD.Numero;
      f_VerVD._UsuarioId = _UsuarioId;
      f_VerVD._Usuario = _Usuario;
      f_VerVD._NroDeActa = VD.NroDeActa;
      f_VerVD.Text = "Verificacion de Deuda N° " + dgv_VD.CurrentRow.Cells["Id"].Value + " - Empresa: " + dgv_VD.CurrentRow.Cells["VD_Empresa"].Value;
      f_VerVD.Lbl_VDDetalle.Text = "Detalle de Verificacione de deuda  N° " + VD.Numero.ToString();
      f_VerVD.Show();

    }

    private void dgv_VD_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }
  }
}
