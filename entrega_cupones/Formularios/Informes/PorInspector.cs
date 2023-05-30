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

namespace entrega_cupones.Formularios.Informes
{
  public partial class PorInspector : Form
  {
    public PorInspector()
    {
      InitializeComponent();
    }

    private void PorInspector_Load(object sender, EventArgs e)
    {
      // dgv1.DataSource = MtdInformes.EmpresasQueNoDeclaran(Convert.ToDateTime("01/01/2021"), Convert.ToDateTime("01/07/2021"));
    }

    private void Btn_Calcular_Click(object sender, EventArgs e)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var M = from a in context.ddjj.
                Where(x => (x.periodo >= DateTime.Now.AddMonths(-3)) && (x.impo <= Convert.ToDouble(Txt_Importe.Text)))
                join Empresa in context.maeemp on a.CUIT_STR equals Empresa.MEEMP_CUIT_STR
                join Empleado in context.maesoc on a.CUIL_STR equals Empleado.MAESOC_CUIL_STR
                orderby Empresa.MAEEMP_RAZSOC, Empleado.APENOM
                select new
                {
                  Periodo = a.periodo,
                  Empresa = Empresa.MAEEMP_RAZSOC,
                  CUIT = Empresa.MEEMP_CUIT_STR,
                  Empleado = Empleado.APENOM,
                  Sueldo = a.impo,
                  Jornada = a.jorp? "Completa":"Parcial"
                };
        dgv1.DataSource = M;
      }
    }
  }
}