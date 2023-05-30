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
  public partial class Frm_Padron : Form
  {
    List<mdlSocio> _Padron = new List<mdlSocio>();

    public Frm_Padron()
    {
      InitializeComponent();
    }

    private void Frm_Padron_Load(object sender, EventArgs e)
    {


      Dgv_Padron.AutoGenerateColumns = false;

      var padron = MtdPadron.GetPadron().OrderBy(x => x.ApeNom);
      _Padron.Clear();
      _Padron.AddRange(padron);
      Dgv_Padron.DataSource = _Padron.ToList();
      Txt_TotalSocios.Text = _Padron.Count().ToString();
      Txt_NoParticipan.Text = _Padron.Count(x => x.GrupoSanguineo == true).ToString();
      Txt_Participan.Text = _Padron.Count(x => x.GrupoSanguineo == false).ToString();
      Pintar();
      Cbx_Ordenar.SelectedIndex = 1;
      Cbx_Sexo.SelectedIndex = 0;

    }


    private void Pintar()
    {
      foreach (DataGridViewRow fila in Dgv_Padron.Rows)
      {
        if (Convert.ToBoolean(fila.Cells["Sorteo"].Value))
        {
          fila.DefaultCellStyle.BackColor = Color.PaleGreen;
        }
        else
        {
          fila.DefaultCellStyle.BackColor = Color.White;
        }
      }
    }
    private void Dgv_Padron_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void Dgv_Padron_SelectionChanged(object sender, EventArgs e)
    {

      var foto = mtdSocios.get_foto_titular_binary(Convert.ToDouble(Dgv_Padron.CurrentRow.Cells["CUIL"].Value));

      mtdConvertirImagen.ByteArrayToImage(foto.ToArray());

      picbox_socio.Image = mtdConvertirImagen.ByteArrayToImage(foto.ToArray());

      MostrarBeneficiarios(Convert.ToDouble(Dgv_Padron.CurrentRow.Cells["CUIL"].Value));
    }

    private void Dgv_Padron_KeyDown(object sender, KeyEventArgs e)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        if (e.KeyCode == Keys.Space)
        {
          var Sorteo = from a in context.maesoc.Where(x => x.MAESOC_CUIL_STR == Dgv_Padron.CurrentRow.Cells["CUIL"].Value.ToString()) select a;

          if (Convert.ToBoolean(Dgv_Padron.CurrentRow.Cells["Sorteo"].Value))
          {
            Sorteo.Single().MAESOC_GRUPOSANG = 0;
            Dgv_Padron.CurrentRow.Cells["Sorteo"].Value = false;
            //Dgv_Padron.CurrentRow.DefaultCellStyle.Font = new Font(Dgv_Padron.Font, FontStyle.Regular);
            Dgv_Padron.CurrentRow.DefaultCellStyle.BackColor = Color.White;

          }
          else
          {
            Sorteo.Single().MAESOC_GRUPOSANG = 1;
            Dgv_Padron.CurrentRow.Cells["Sorteo"].Value = true;
            //Dgv_Padron.ColumnHeadersDefaultCellStyle.Font = new Font(Dgv_Padron.Font, FontStyle.Bold);
            // Dgv_Padron.CurrentRow.DefaultCellStyle.Font = new Font(Dgv_Padron.Font, FontStyle.Bold);
            Dgv_Padron.CurrentRow.DefaultCellStyle.BackColor = Color.PaleGreen;
          }
          context.SubmitChanges();
          Txt_NoParticipan.Text = _Padron.Count(x => x.GrupoSanguineo == true).ToString();
          Txt_Participan.Text = _Padron.Count(x => x.GrupoSanguineo == false).ToString();
          //Dgv_Padron.CurrentRow.Cells["Sorteo"].Value = Convert.ToBoolean(Dgv_Padron.CurrentRow.Cells["Sorteo"].Value) == true ? false : true;
        }
      }
    }

    private void Btn_Guardar_Click(object sender, EventArgs e)
    {

    }

    private void Cbx_Ordenar_SelectedIndexChanged(object sender, EventArgs e)
    {
      Ordenar();
    }

    private void Cbx_Sexo_SelectedIndexChanged(object sender, EventArgs e)
    {
      Ordenar();
    }

    private void Ordenar()
    {
      string Sexo = "";

      switch (Cbx_Sexo.SelectedIndex)
      {
        case 0:
          Sexo = "T";
          break;
        case 1:
          Sexo = "F";
          break;
        case 2:
          Sexo = "M";
          break;
        default:
          break;
      }


      switch (Cbx_Ordenar.SelectedIndex)
      {
        case 0:
          Dgv_Padron.DataSource = _Padron.Where(x => Cbx_Sexo.SelectedIndex == 0 ? x.Sexo != "T" : x.Sexo == Sexo).OrderBy(x => x.NroDeSocio).ToList(); //(Cbx_Sexo.SelectedIndex == 0 ? x.Sexo != "T" : x.Sexo == Sexo) ).ToList();

          //Dgv_Padron.DataSource = _Padron.Where(x =>  x.Sexo == Sexo).OrderBy(x => x.NroDeSocio).ToList(); //(Cbx_Sexo.SelectedIndex == 0 ? x.Sexo != "T" : x.Sexo == Sexo) ).ToList();
          break;
        case 1:
          Dgv_Padron.DataSource = _Padron.Where(x => Cbx_Sexo.SelectedIndex == 0 ? x.Sexo != "T" : x.Sexo == Sexo).OrderBy(x => x.ApeNom).ToList();
          break;
        case 2:
          Dgv_Padron.DataSource = _Padron.Where(x => Cbx_Sexo.SelectedIndex == 0 ? x.Sexo != "T" : x.Sexo == Sexo).OrderBy(x => x.NroDNI).ToList();
          break;
        case 3:
          Dgv_Padron.DataSource = _Padron.Where(x => Cbx_Sexo.SelectedIndex == 0 ? x.Sexo != "T" : x.Sexo == Sexo).OrderBy(x => x.RazonSocial).ToList();
          break;
        case 4:
          Dgv_Padron.DataSource = _Padron.Where(x => Cbx_Sexo.SelectedIndex == 0 ? x.Sexo != "T" : x.Sexo == Sexo).OrderBy(x => x.CUIT).ToList();
          break;
        case 5:
          Dgv_Padron.DataSource = _Padron.Where(x => Cbx_Sexo.SelectedIndex == 0 ? x.Sexo != "T" : x.Sexo == Sexo).OrderBy(x => x.LastDDJJ).ToList();
          break;
        default:
          break;
      }
      Pintar();
    }

    private void MostrarBeneficiarios(double cuil)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        socios soc = new socios();
        var Beneficiario = from a in context.socflia
                           join Familiar in context.maeflia on a.SOCFLIA_CODFLIAR equals Familiar.MAEFLIA_CODFLIAR
                           where a.SOCFLIA_CUIL == cuil
                           select new
                           {
                             Nombre = Familiar.MAEFLIA_APELLIDO.Trim() + " " + Familiar.MAEFLIA_NOMBRE.Trim(),
                             Parentesco = (a.SOCFLIA_PARENT == 1) ? "CONYUGE" :
                                                    (a.SOCFLIA_PARENT == 2) ? "HIJO MENOR DE 16" :
                                                    (a.SOCFLIA_PARENT == 3) ? "HIJO MENOR DE 18" :
                                                    (a.SOCFLIA_PARENT == 4) ? "HIJO MENOR DE 21" :
                                                    (a.SOCFLIA_PARENT == 5) ? "HIJO MAYOR DE 21" : "",
                             CodigoDeBenef = Familiar.MAEFLIA_CODFLIAR,
                             DNI = Familiar.MAEFLIA_NRODOC,
                             FechaDeNacimiento = Familiar.MAEFLIA_FECNAC,
                             Edad = soc.calcular_edad(Familiar.MAEFLIA_FECNAC)
                           };
        dgv_MostrarBeneficiario.DataSource = Beneficiario.ToList();
        if (Beneficiario.Count() == 0)
        {
          picbox_beneficiario.Image = null;
          lbl_Parentesco.Text = "-----";
        }
        lbl_SinRegistrosBeneficiarios.Visible = Beneficiario.Count() > 0 ? false : true;
      }
    }

    private void dgv_MostrarBeneficiario_SelectionChanged(object sender, EventArgs e)
    {
      MostrarFotoBeneficiario(Convert.ToDouble(dgv_MostrarBeneficiario.CurrentRow.Cells["codigo_fliar"].Value));
    }

    private void MostrarFotoBeneficiario(double CodigoDeFamiliar)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        convertir_imagen cnvimg = new convertir_imagen();
        socios soc = new socios();

        var foto = soc.get_foto_benef_binary(CodigoDeFamiliar);
        picbox_beneficiario.Image = cnvimg.ByteArrayToImage(foto.ToArray());
        lbl_Parentesco.Text = dgv_MostrarBeneficiario.CurrentRow.Cells["parentesco"].Value.ToString();
      }
    }

  }
}

