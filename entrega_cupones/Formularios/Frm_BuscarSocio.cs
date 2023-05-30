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
using static entrega_cupones.Clases.Buscadores;

namespace entrega_cupones.Formularios
{
  public partial class Frm_BuscarSocio : Form
  {

    List<mdlSocio> _SociosABuscar = new List<mdlSocio>();
   

    public Frm_BuscarSocio()
    {
      InitializeComponent();
    }
    private void Btn_BuscarSocio_Click(object sender, EventArgs e)
    {

    }

    private void Frm_BuscarSocio_Load(object sender, EventArgs e)
    {
      Dgv_Socios.AutoGenerateColumns = false;
      Cbx_Filtrar.SelectedIndex = 0;
      Dgv_Socios.DataSource = _SociosABuscar = mtdSocios.GetMaeSoc();
      Txt_CantidadSocios.Text = _SociosABuscar.Count(x => x.EsSocioString == "SI").ToString("N0");
      CargarCbxEmpresas();
    }

    private void CargarCbxEmpresas()
    {
      Cbx_Empresa.DisplayMember = "MAEEMP_RAZSOC";
      Cbx_Empresa.ValueMember = "MEEMP_CUIT_STR";
      Cbx_Empresa.DataSource = mtdEmpresas.GetListadoEmpresas(); //mtdInspectores.Get_Inspectores();
      Cbx_Empresa.MaxDropDownItems = 10;
    }

    private void txt_buscar_TextChanged(object sender, EventArgs e)
    {
      MostrarListaSocios();
    }

    public void MostrarListaSocios()
    {

      var xxx = mtdSocios.GetSocioBuscado
        (_SociosABuscar, Txt_Buscar.Text.ToUpper(), Cbx_Filtrar.SelectedIndex, Convert.ToString(Cbx_Empresa.SelectedValue),0,0,0,0);
      if (xxx.Count() > 0)
      {
        Dgv_Socios.DataSource = xxx;
        Txt_CantidadSocios.Text = xxx.Count(x => x.EsSocioString == "SI").ToString("N0");
      }
      else
      {
        Dgv_Socios.DataSource = null;
        PicBox_FotoSocio.Image = null;
        Txt_CantidadSocios.Text = "0";
      }
    }


    private void Dgv_Socios_SelectionChanged(object sender, EventArgs e)
    {
      MostrarDatosDelSocio();
      btn_Confirmar.Enabled = Dgv_Socios.CurrentRow.Cells["EsSocio"].Value.ToString() == "SI";
    }

    private void MostrarDatosDelSocio()
    {
      var x = Convert.ToDouble(Dgv_Socios.CurrentRow.Cells["CUIL"].Value);
      PicBox_FotoSocio.Image = mtdConvertirImagen.ConvertByteArrayToImage(mtdSocios.get_foto_titular_binary(x).ToArray());
      Txt_Empresa.Text = mtdEmpresas.GetEmpresaNombre(Dgv_Socios.CurrentRow.Cells["CUIL"].Value.ToString());
    }

    private void btn_Confirmar_Click(object sender, EventArgs e)
    {
      if (Dgv_Socios.CurrentRow.Cells["EsSocio"].Value.ToString() == "SI")
      {
        Frm_Quinchos F_Quinchos = Owner as Frm_Quinchos;
        F_Quinchos.Txt_Socio.Text = Dgv_Socios.CurrentRow.Cells["ApeNom"].Value.ToString();
        Close();
        //F_Quinchos.Nombre = "Hola";
      }
    }

    private void Btn_Salir_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void Dgv_Socios_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void Cbx_Filtrar_SelectedIndexChanged(object sender, EventArgs e)
    {
      MostrarListaSocios();

    }

    private void Cbx_Empresa_SelectedIndexChanged(object sender, EventArgs e)
    {
      MostrarListaSocios();
    }
  }
}