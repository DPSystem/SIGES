using entrega_cupones.Clases;
using entrega_cupones.Metodos;
using entrega_cupones.Modelos;
using MySqlX.XDevAPI.Relational;
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


  public partial class Frm_PadronSECPJ : Form
  {
    List<MdlSECPJ> _PadronSECPJ = new List<MdlSECPJ>();

    public Frm_PadronSECPJ()
    {
      InitializeComponent();
    }

    private void Frm_PadronSECPJ_Load(object sender, EventArgs e)
    {


      // Dgv_Padron.AutoGenerateColumns = false;

      var padron = MtdPadron.GetPadronSECPJ().OrderBy(x => x.ApellidoyNombres);
      _PadronSECPJ.Clear();
      _PadronSECPJ.AddRange(padron);
      Dgv_Padron.DataSource = _PadronSECPJ.ToList();
      Txt_TotalSocios.Text = _PadronSECPJ.Count().ToString();
      //Txt_NoParticipan.Text = _PadronSECPJ.Count(x => x.GrupoSanguineo == true).ToString();
      //Txt_Participan.Text = _PadronSECPJ.Count(x => x.GrupoSanguineo == false).ToString();
      //Pintar();
      Cbx_Ordenar.SelectedIndex = 1;
      Cbx_Sexo.SelectedIndex = 0;
    }

    private void Dgv_Padron_SelectionChanged(object sender, EventArgs e)
    {
      var foto = mtdSocios.get_foto_titular_binary(Convert.ToDouble(Dgv_Padron.CurrentRow.Cells["CUIL"].Value));

      mtdConvertirImagen.ByteArrayToImage(foto.ToArray());

      picbox_socio.Image = mtdConvertirImagen.ByteArrayToImage(foto.ToArray());

    }

    private void Btn_Imprimir_Click(object sender, EventArgs e)
    {
      Imprimir();
    }

    private void Imprimir()
    {
      DS_cupones Ds = new DS_cupones();
      DataTable Dt = Ds.PadronSECPJ;
      Dt.Clear();
      foreach (var item in _PadronSECPJ)
      {
        DataRow Row = Dt.NewRow();
        Row["CodSeccion"] = item.CodSeccion;
        Row["Seccion"] = item.Seccion;
        Row["CodCircuito"] = item.CodCircuito;
        Row["Circuito"] = item.Circuito;
        Row["Apellido"] = item.Apellido;
        Row["Nombre"] = item.Nombre;
        Row["ApellidoyNombres"] = item.ApellidoyNombres;
        Row["Genero"] = item.Genero;
        Row["Tipodocumento"] = item.Tipodocumento;
        Row["Matricula"] =Convert.ToDecimal( item.Matricula).ToString("N0");
        Row["Fechanacimiento"] = item.Fechanacimiento;
        Row["Clase"] = item.Clase;
        Row["DescTipoPadron"] = item.DescTipoPadron;
        Row["EstadoAfiliacion"] = item.EstadoAfiliacion;
        Row["FechaAfiliacion"] = item.FechaAfiliacion;
        Row["Analfabeto"] = item.Analfabeto;
        Row["Profesion"] = item.Profesion;
        Row["Fechadomicilio"] = item.Fechadomicilio;
        Row["Domicilio"] = item.Domicilio;
        Dt.Rows.Add(Row);
      }

      reportes F_Reportes = new reportes
      {
        dt = Dt,
        NombreDelReporte = "entrega_cupones.Reportes.Rpt_PadronSECPJ.rdlc"
      };
      F_Reportes.Show();

    }
  }
}
