using entrega_cupones.Metodos;
using entrega_cupones.Modelos;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entrega_cupones.Formularios.Tesoreria
{
  public partial class Frm_InformeComparativoDDJJPagosActas : Form
  {
    List<Mdl_InformeDDJJCobrosActas> _InformeDDJJCobrosActas = new List<Mdl_InformeDDJJCobrosActas>();

    List<ddjjt> _DDJJ = new List<ddjjt>();

    List<EstadoDDJJ> _ddjj = new List<EstadoDDJJ>();

    int _Index = 0;

    public Frm_InformeComparativoDDJJPagosActas()
    {
      InitializeComponent();
    }

    private void Frm_InformeComparativoDDJJPagosActas_Load(object sender, EventArgs e)
    {
      Dgv_EmpresasConDeuda.AutoGenerateColumns = false;
      dgv_ddjj.AutoGenerateColumns = false;

    }

    private void ListarPeriodos()
    {
      this.Cursor = Cursors.WaitCursor;
      using (var context = new lts_sindicatoDataContext())
      {
        _ddjj.Clear();
        _InformeDDJJCobrosActas.Clear();
        DateTime Desde = Convert.ToDateTime("01/" + Cbx_PeriodoDesde.Text); //DateTime.Now.AddYears(-3);
        DateTime Hasta = Convert.ToDateTime("01/" + Cbx_PeriodoHasta.Text);

        var _EstadoDDJJ = context.ddjjt.Where(x => ((x.periodo >= Desde) && (x.periodo <= Hasta)))// && x.periodo <= hasta))
        .Select(row => new EstadoDDJJ
        {
          Periodo = Convert.ToDateTime(row.periodo),
          Rectificacion = (int)row.rect,
          AporteLey = (decimal)row.titem1,
          AporteSocio = (decimal)row.titem2,
          TotalSueldoEmpleados = (decimal)row.titem1 / Convert.ToDecimal(0.02),
          TotalSueldoSocios = (decimal)row.titem2 / Convert.ToDecimal(0.02),
          FechaDePago = row.fpago == null ? null : row.fpago,
          ImporteDepositado = (decimal)row.impban1,
          InteresCobrado = (decimal)(row.ctrlimp == 0 ? row.ctrlimp : row.ctrlimp > 0 ? row.ctrlimp : ((row.ctrlimp) * (-1))),
          CUIT_STR = row.CUIT_STR
        });


        _ddjj.AddRange(_EstadoDDJJ);
        _ddjj.RemoveAll(x => (x.AporteLey == 0) && (x.AporteSocio == 0) && (x.InteresCobrado == 0) && (x.ImporteDepositado > 0));

        EliminarRectificacion();

        var informe = (from a in _ddjj.Where(x => x.Periodo >= Desde)
                       group a by a.Periodo into gp
                       select new Mdl_InformeDDJJCobrosActas
                       {
                         Periodo = gp.Key,
                         ImporteDDJJ = (decimal)(gp.Sum(x => x.AporteLey + x.AporteSocio)),
                         CobradoDDJJ = (decimal)(gp.Sum(x => x.ImporteDepositado - x.InteresCobrado)),
                         FaltaCobrar = (decimal)gp.Sum(x => (x.AporteLey + x.AporteSocio) - (x.ImporteDepositado - x.InteresCobrado)),
                         PorcentajeDeMora = (decimal)(gp.Where(x => x.ImporteDepositado == 0).Sum(x => (x.AporteLey + x.AporteSocio)) * 100)
                                            / ((gp.Sum(x => x.AporteLey + x.AporteSocio)))
                       }).OrderBy(x => x.Periodo);

        _InformeDDJJCobrosActas.AddRange(informe);

        MostrarTotales();

        dgv_ddjj.DataSource = _InformeDDJJCobrosActas.ToList();//.OrderBy(x => x.Periodo).ToList();
        this.Cursor = Cursors.Default;
      }
    }

    public void EliminarRectificacion()
    {
      var agrupado = _ddjj.GroupBy(x => new { x.Periodo, x.CUIT_STR }).Where(x => x.Count() > 1);

      foreach (var item in agrupado)
      {
        decimal Pagado = item.Sum(x => x.ImporteDepositado);
        var MayorRectif = item.Max(x => x.Rectificacion);
        foreach (var registro in item)
        {
          if (Pagado > 0)
          {
            int rect = registro.Rectificacion;
            decimal ImporteDepositado = registro.ImporteDepositado;
            if (registro.ImporteDepositado > 0)
            {
              _ddjj.RemoveAll(x => (x.CUIT_STR == item.Key.CUIT_STR && x.Periodo == item.Key.Periodo) && (x.Rectificacion != registro.Rectificacion));
            }
            else
            {
              _ddjj.RemoveAll(x => (x.CUIT_STR == item.Key.CUIT_STR && x.Periodo == item.Key.Periodo) && (x.Rectificacion == registro.Rectificacion));
            }
          }
          else
          {
            _ddjj.RemoveAll(x => (x.CUIT_STR == item.Key.CUIT_STR && x.Periodo == item.Key.Periodo) && (x.Rectificacion != MayorRectif));
          }
        }
      }
    }
    private void MostrarTotales()
    {
      Txt_TotalDDJJ.Text = _InformeDDJJCobrosActas.Sum(x => x.ImporteDDJJ).ToString("N2");
      Txt_TotalDDJJCobradas.Text = _InformeDDJJCobrosActas.Sum(x => x.CobradoDDJJ).ToString("N2");
      Txt_TotalDDJJFaltanCobrar.Text = _InformeDDJJCobrosActas.Sum(x => x.FaltaCobrar).ToString("N2");
      Txt_PorcentajeDeMora.Text = _InformeDDJJCobrosActas.Sum(x => x.PorcentajeDeMora).ToString("N2");
      
    }

    private void dgv_ddjj_SelectionChanged(object sender, EventArgs e)
    {
      DateTime Periodo = Convert.ToDateTime(dgv_ddjj.CurrentRow.Cells["Periodo"].Value);
      using (var context = new lts_sindicatoDataContext())
      {

        var DDD = (from a in _ddjj.Where(x =>
                   (x.Periodo == Periodo)
                   //&& (x.ImporteDepositado == 0)
                   && (((x.AporteLey + x.AporteSocio) - (x.ImporteDepositado - x.InteresCobrado)) > 0)
                   )
                   select new
                   {
                     CUIT = a.CUIT_STR,
                     Empresa = mtdEmpresas.GetEmpresaNombre(a.CUIT_STR),
                     Deuda = (decimal)((a.AporteLey + a.AporteSocio) - (a.ImporteDepositado - a.InteresCobrado)),
                     //Deuda = (decimal)((a.AporteLey + a.AporteSocio)),
                     //Periodo = a.Periodo,
                   }).OrderByDescending(x => x.Deuda).ToList();
        Dgv_EmpresasConDeuda.DataSource = DDD;
        Txt_Importe.Text = DDD.Sum(x => x.Deuda).ToString("N2");
        Txt_CantidadEmpresas.Text = DDD.Count().ToString("N0");
      }
    }

    private void dgv_ddjj_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void Cbx_PeriodoDesde_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void Cbx_Hasta_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void Btn_ListarPeriodos_Click(object sender, EventArgs e)
    {
      ListarPeriodos();
    }
  }
}
