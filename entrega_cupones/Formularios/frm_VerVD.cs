using entrega_cupones.Clases;
using entrega_cupones.Metodos;
using entrega_cupones.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entrega_cupones.Formularios
{
  public partial class frm_VerVD : Form
  {
    public List<mdlVDInspector> _VD_Inspcetor = new List<mdlVDInspector>();

    public List<mdlVDDetalle> _VDDetalle = new List<mdlVDDetalle>();

    public List<EstadoDDJJ> _ddjjNoIncorporadas = new List<EstadoDDJJ>();

    public int _UsuarioId;
    public string _Usuario;
    public int _VDId;
    public int _NumeroVD;
    public int _NroDeActa;
    public int _NroDePlanDePago;

    public List<mdlDDJJEmpleado> _DDJJEmpleados = new List<mdlDDJJEmpleado>();

    List<MdlPlanDePagoDetalle> _PlanDePagoDGV = new List<MdlPlanDePagoDetalle>();

    public int _PlanDePagoInsert;

    public List<int> PeriodosEliminar = new List<int>();

    public frm_VerVD()
    {
      InitializeComponent();

    }

    private void frm_VerVD_Load(object sender, EventArgs e)
    {
      dgv_VD.AutoGenerateColumns = false;
      dgv_PlanDePagos.AutoGenerateColumns = false;
      Dgv_PeriodosNoIncorporados.AutoGenerateColumns = false;
      _VD_Inspcetor = mtdVDInspector.Get_VD(_VDId);
      Cargar_cbxInspectores();
      MostarDatosVD();
      VD_Mostrar();
      MostarPlanDePagoCabecera();
      CalcularTotales();
      MostrarPeriodosNoIncorporados();
      PintarPerNoDec();
      if (_NroDeActa > 0)
      {
        TS_MenuDetalleVD.Enabled = false;
        //TS_PlanDePago.Enabled = false;
        TSB_Calcular.Enabled = false;
        TSB_Confirmar.Enabled = false;  
      }
    }

    private void MostarDatosVD()
    {
      var VD = _VD_Inspcetor.SingleOrDefault();

      txt_CUIT.Text = VD.CUIT;
      txt_BuscarEmpesa.Text = VD.Empresa;
      txt_Domicilio.Text = VD.Domicilio;
      msk_Desde.Text = mtdFuncUtiles.generar_ceros(Convert.ToDateTime(VD.Desde).Month.ToString(), 2) + Convert.ToDateTime(VD.Desde).Year.ToString();
      msk_Hasta.Text = mtdFuncUtiles.generar_ceros(Convert.ToDateTime(VD.Hasta).Month.ToString(), 2) + Convert.ToDateTime(VD.Hasta).Year.ToString();
      msk_Vencimiento.Text = VD.FechaVenc.ToString();
      cbx_TipoDeInteres.SelectedIndex = (int)VD.TipoInteres;
      txt_Interes.Text = VD.InteresMensual.ToString();
      txt_InteresDiario.Text = VD.InteresDiario.ToString();
      cbx_Inspectores.Text = mtdInspectores.Get_InspectorNombre(VD.InspectorId);

    }

    private void VD_Mostrar()
    {
      _VDDetalle = mtdVDDetalle.Get_VDD(_VDId);
      dgv_VD.DataSource = _VDDetalle;


      //BindingSource bindingSource = new BindingSource();
      //BindingSource.DataSource = _VDDetalle;
    }

    private void MostarPlanDePagoCabecera()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var PlanDePago = (from a in context.VD_PlanesDePago.Where(x => x.NumeroVD == _NumeroVD)
                          select a).FirstOrDefault();

        if (PlanDePago != null)
        {
          txt_DeudaInicial.Text = PlanDePago.Deuda.ToString();
          Txt_Ajuste.Text = PlanDePago.Ajuste.ToString();
          Txt_DeudaConAjuste.Text = PlanDePago.DeudaConAjuste.ToString();
          Txt_InteresDeFinanciacion.Text = PlanDePago.InteresFinanciacionPorcentaje.ToString();
          Txt_ImporteInteresDeFinanciacion.Text = PlanDePago.InteresFinanciacionImporte.ToString();
          Txt_TotalDeuda.Text = PlanDePago.DeudaConInteres.ToString();
          Txt_Anticipo.Text = PlanDePago.Anticipo.ToString();
          Dtp_VencAnticipo.Value = Convert.ToDateTime(PlanDePago.AnticipoVencimiento);
          Txt_SubTotal.Text = PlanDePago.DeudaAFinanciar.ToString();
          Cbx_CantidadDeCuotas.SelectedIndex = (int)(PlanDePago.Cuotas - 1);
          Txt_ImporteDeCuota.Text = PlanDePago.CuotasImporte.ToString();
          Dtp_VencCuota.Value = Convert.ToDateTime(PlanDePago.CuotaVencimiento);
          Txt_Comentario.Text = PlanDePago.Comentario;
          Lbl_PlanDePago.Text = "Plan de Pago N° " + PlanDePago.Numero.ToString();
          _NroDePlanDePago = (int)PlanDePago.Numero;

        }
        else
        {
          _PlanDePagoInsert = 0;
          Lbl_PlanDePago.Text = "Plan de Pago [ No Generado ]";
        }
      }

    }

    private void PintarPerNoDec()
    {
      foreach (DataGridViewRow fila in Dgv_PeriodosNoIncorporados.Rows)
      {
        if (Convert.ToInt32(fila.Cells["PerNoDec1"].Value) == 1)
        {
          fila.DefaultCellStyle.BackColor = System.Drawing.Color.PaleVioletRed;
        }
      }
    }

    private void Cargar_cbxInspectores()
    {
      cbx_Inspectores.DisplayMember = "Nombre";
      cbx_Inspectores.ValueMember = "Id";
      cbx_Inspectores.DataSource = mtdInspectores.Get_Inspectores();
    }

    private void Cargar_DDJJEmpleado()
    {
      _DDJJEmpleados.Clear();
      _DDJJEmpleados = mtdEmpleados.ListadoEmpleadoAporte
        (
        txt_CUIT.Text,
        Convert.ToDateTime(dgv_VD.CurrentRow.Cells["Periodo"].Value),
        Convert.ToInt32(dgv_VD.CurrentRow.Cells["Rectificacion"].Value)
        );

    }

    private void CalcularTotales()
    {
      decimal InteresResarcitorio = _VDDetalle.Where(x => x.NumeroDeActa == 0 && x.DiasDeMora > 0 && x.FechaDePago != null).Sum(x => x.DeudaGenerada);
      txt_Total.Text = Math.Round(_VDDetalle.Where(x => x.NumeroDeActa == 0).Sum(x => x.Total), 2).ToString("N2");
      txt_Pagado.Text = Math.Round(_VDDetalle.Where(x => x.NumeroDeActa == 0).Sum(x => x.ImporteDepositado), 2).ToString("N2");
      txt_Deuda.Text = Math.Round(_VDDetalle.Where(x => x.NumeroDeActa == 0 && x.DiasDeMora > 0 && x.FechaDePago == null).Sum(x => x.DeudaGenerada), 2).ToString("N2");
      txt_TotalInteres.Text = Math.Round(_VDDetalle.Where(x => x.NumeroDeActa == 0).Sum(x => x.InteresGenerado) + InteresResarcitorio, 2).ToString("N2");
      txt_PerNoDec.Text = _VDDetalle.Where(x => x.NumeroDeActa == 0).Count(x => x.PerNoDec == 1).ToString();
      txt_DeudaInicial.Text = txt_Total.Text;

      MostrarPlanDePago();
    }

    private void MostrarPlanDePago()
    {
      decimal DeudaInicial = Convert.ToDecimal(txt_DeudaInicial.Text);
      decimal Ajuste = string.IsNullOrEmpty(Txt_Ajuste.Text.Trim()) ? 0 : Convert.ToDecimal(Txt_Ajuste.Text);
      decimal DeudaConAjuste = DeudaInicial + Ajuste;
      decimal Anticipo = string.IsNullOrEmpty(Txt_Anticipo.Text.Trim()) ? 0 : Convert.ToDecimal(Txt_Anticipo.Text);
      decimal SubTotal = DeudaConAjuste - Anticipo;

      decimal Interes = string.IsNullOrWhiteSpace(Txt_InteresDeFinanciacion.Text.Trim()) ? 0 : Convert.ToDecimal(Txt_InteresDeFinanciacion.Text);
      decimal CantidadDeCuotas = Cbx_CantidadDeCuotas.SelectedIndex == -1 ? 1 : Cbx_CantidadDeCuotas.SelectedIndex + 1;
      decimal MontoDeInteres = ((SubTotal * Interes * CantidadDeCuotas) / 100);

      decimal DeudaConInteres = SubTotal + MontoDeInteres;

      decimal MontoDeCuota = DeudaConInteres / CantidadDeCuotas;


      Txt_DeudaConAjuste.Text = DeudaConAjuste.ToString("N2");
      Txt_SubTotal.Text = SubTotal.ToString("N2");

      Txt_ImporteInteresDeFinanciacion.Text = MontoDeInteres.ToString("N2");
      Txt_ImporteDeCuota.Text = MontoDeCuota.ToString("N2");
      Txt_TotalDeuda.Text = DeudaConInteres.ToString("N2");

      //CalcularAnticipo();
      //CalcularCuota();
      CargarDgv_PlanDePago();
    }

    private void MostrarPeriodosNoIncorporados()
    {
      //var Desde = _VDDetalle.Max(x => x.Periodo).Value;
      var Desde = Convert.ToDateTime(msk_Desde.Text);
      _ddjjNoIncorporadas = mtdEmpresas.ListadoDDJJT(
        txt_CUIT.Text,
        Desde,
        DateTime.Now.Date, //Convert.ToDateTime("01/" + msk_Hasta.Text),
        Convert.ToDateTime(msk_Vencimiento.Text),
        cbx_TipoDeInteres.SelectedIndex,
       Convert.ToDecimal(txt_InteresDiario.Text)
        );
      foreach (var item in _VDDetalle)
      {
        _ddjjNoIncorporadas.RemoveAll(x => x.Periodo == item.Periodo);
      }
      Dgv_PeriodosNoIncorporados.DataSource = _ddjjNoIncorporadas;
    }

    private void Simulacion()
    {
      EliminarPeriodo();
      _VDDetalle = mtdVDDetalle.VD_Simulacion(_VDDetalle,
                    txt_CUIT.Text,
                    Convert.ToDateTime("01/" + msk_Desde.Text),
                    Convert.ToDateTime("01/" + msk_Hasta.Text),
                    Convert.ToDateTime(msk_Vencimiento.Text),
                    cbx_TipoDeInteres.SelectedIndex,
                    Convert.ToDecimal(txt_InteresDiario.Text),
                    _VDId
                    );
      dgv_VD.DataSource = _VDDetalle;
      CalcularTotales();
    }

    private void InsertPerNoInc()
    {
      int Indice = Dgv_PeriodosNoIncorporados.CurrentRow.Index;
      mdlVDDetalle InsertPerido = new mdlVDDetalle
      {
        Periodo = Convert.ToDateTime(_ddjjNoIncorporadas[Indice].Periodo), // Convert.ToDateTime(row.Periodo),
        Rectificacion = (int)_ddjjNoIncorporadas[Indice].Rectificacion,
        TotalAporteEmpleados = (decimal)_ddjjNoIncorporadas[Indice].AporteLey,
        TotalAporteSocios = (decimal)_ddjjNoIncorporadas[Indice].AporteSocio,
        TotalSueldoEmpleados = (decimal)_ddjjNoIncorporadas[Indice].TotalSueldoEmpleados, /*.titem1 / Convert.ToDecimal(0.02)*/
        TotalSueldoSocios = (decimal)_ddjjNoIncorporadas[Indice].TotalSueldoSocios, //.titem2 / Convert.ToDecimal(0.02),
        FechaDePago = _ddjjNoIncorporadas[Indice].FechaDePago == null ? null : _ddjjNoIncorporadas[Indice].FechaDePago, //.fpago == null ? null : row.fpago,
        ImporteDepositado = (decimal)_ddjjNoIncorporadas[Indice].ImporteDepositado, //row.impban1,
        CantidadEmpleados = _ddjjNoIncorporadas[Indice].Empleados,//context.ddjj.Where(x => x.CUIT_STR == cuit && (x.periodo == row.periodo) && (x.rect == row.rect)).Count(),
        CantidadSocios = _ddjjNoIncorporadas[Indice].Socios,//context.ddjj.Where(x => x.CUIT_STR == cuit && (x.periodo == row.periodo) && x.rect == row.rect && x.item2 == true).Count(),
        DeudaGenerada = _ddjjNoIncorporadas[Indice].Capital,
        InteresGenerado = _ddjjNoIncorporadas[Indice].Interes,
        DiasDeMora = _ddjjNoIncorporadas[Indice].DiasDeMora,
        Total = (decimal)_ddjjNoIncorporadas[Indice].Total
      };
      _VDDetalle.Add(InsertPerido);
      dgv_VD.DataSource = null;
      dgv_VD.DataSource = _VDDetalle;

      _ddjjNoIncorporadas.RemoveAt(Indice); // Elimino el periodo incorporado 
      Dgv_PeriodosNoIncorporados.DataSource = null;
      Dgv_PeriodosNoIncorporados.DataSource = _ddjjNoIncorporadas;
    }

    private void btn_Actualizar_VD_Click(object sender, EventArgs e)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        foreach (var periodo in _VDDetalle)
        {
          var VDDetalle = context.VD_Detalle.Where(x => x.Id == periodo.Id).SingleOrDefault();

          DateTime? FechaDePago = null;

          if (periodo.FechaDePago != null)
          {
            FechaDePago = Convert.ToDateTime(periodo.FechaDePago);
          }

          // Pregunto por el Periodo.Id == 0 por que si es asi entonces es un perido para insertar
          if (periodo.Id == 0)
          {
            VD_Detalle VDD = new VD_Detalle
            {
              VDInspectorId = _VDId,
              Periodo = Convert.ToDateTime(periodo.Periodo),
              Rectificacion = periodo.Rectificacion,
              CantidadEmpleados = (int)periodo.CantidadEmpleados,
              CantidadSocios = (int)periodo.CantidadSocios,
              TotalSueldoEmpleados = periodo.TotalSueldoEmpleados,
              TotalSueldoSocios = periodo.TotalSueldoSocios,
              TotalAporteEmpleados = periodo.TotalAporteEmpleados,
              TotalAporteSocios = periodo.TotalAporteSocios,
              FechaDePago = FechaDePago, //periodo.FechaDePago,
              ImporteDepositado = periodo.ImporteDepositado,
              DiasDeMora = periodo.DiasDeMora,
              DeudaGenerada = periodo.DeudaGenerada,
              InteresGenerado = periodo.InteresGenerado,
              Total = periodo.Total,
              PerNoDec = periodo.PerNoDec,
              ActaId = 0,
              NumeroDeActa = 0,
              Estado = 0
            };
            context.VD_Detalle.InsertOnSubmit(VDD);
            context.SubmitChanges();
          }
          else
          {
            VDDetalle.Periodo = Convert.ToDateTime(periodo.Periodo);
            VDDetalle.Rectificacion = periodo.Rectificacion;
            VDDetalle.CantidadEmpleados = periodo.CantidadEmpleados;
            VDDetalle.CantidadSocios = periodo.CantidadSocios;
            VDDetalle.TotalSueldoEmpleados = periodo.TotalSueldoEmpleados;
            VDDetalle.TotalSueldoSocios = periodo.TotalSueldoSocios;
            VDDetalle.TotalAporteEmpleados = periodo.TotalAporteEmpleados;
            VDDetalle.TotalAporteSocios = periodo.TotalAporteSocios;
            VDDetalle.FechaDePago = FechaDePago;//periodo.FechaDePago == null ? null : Convert.ToDateTime(periodo.FechaDePago);
            VDDetalle.ImporteDepositado = periodo.ImporteDepositado;
            VDDetalle.DiasDeMora = periodo.DiasDeMora;
            VDDetalle.DeudaGenerada = periodo.DeudaGenerada;
            VDDetalle.InteresGenerado = periodo.InteresGenerado;
            VDDetalle.Total = periodo.Total;
            VDDetalle.PerNoDec = periodo.PerNoDec;
            VDDetalle.ActaId = 0;
            VDDetalle.NumeroDeActa = 0;
            VDDetalle.Estado = 0;
            context.SubmitChanges();
          }
        };

        // Actualizo la tabla de VD_Inspector
        var UpdateVD = (from a in context.VD_Inspector where a.Id == _VDId select a).SingleOrDefault();
        UpdateVD.Desde = Convert.ToDateTime(msk_Desde.Text);
        UpdateVD.Hasta = _VDDetalle.Max(x => x.Periodo).Value;

        UpdateVD.FechaVenc = Convert.ToDateTime(msk_Vencimiento.Text);
        UpdateVD.TipoInteres = cbx_TipoDeInteres.SelectedIndex;
        UpdateVD.InteresMensual = Convert.ToDecimal(txt_Interes.Text);
        UpdateVD.InteresDiario = Convert.ToDecimal(txt_InteresDiario.Text);
        UpdateVD.Capital = Convert.ToDecimal(txt_Deuda.Text);         //Math.Round(_ddjj.Sum(x => x.Capital), 2)
        UpdateVD.Interes = Convert.ToDecimal(txt_TotalInteres.Text);
        UpdateVD.Total = Convert.ToDecimal(txt_Total.Text);
        context.SubmitChanges();
      }
    }

    private void txt_Interes_TextChanged(object sender, EventArgs e)
    {
      if (txt_Interes.Text == "")
      {
        txt_Interes.Text = "0";
      }
      txt_InteresDiario.Text = mtdIntereses.CalcularInteresDiario(txt_Interes.Text);
    }

    private void btn_CopiarAnterior_Click(object sender, EventArgs e)
    {
      CopiarPeriodo(false);
    }

    private void btn_CopiarSiguiente_Click(object sender, EventArgs e)
    {
      CopiarPeriodo(true);
    }

    private void CopiarPeriodo(bool CopiarSiguiente)
    {
      // la Fila Actual y obtengo el Id del periodo actual
      int Index = dgv_VD.CurrentRow.Index;
      int VDId_Actual = Convert.ToInt32(dgv_VD.CurrentRow.Cells["Id"].Value);

      // VDD_Id para buscar en _VDDetalle y asi obtener el Id a copiar y lo guardo en la Variable PeriodoACopiar
      int VD_Id = Convert.ToInt32(dgv_VD.Rows[CopiarSiguiente == true ? Index + 1 : Index - 1].Cells["Id"].Value);
      mdlVDDetalle ACopiar = _VDDetalle.FirstOrDefault(x => x.Id == VD_Id);

      decimal TotalSueldoEmpleados = ACopiar.Periodo.Value.Month == 12 || ACopiar.Periodo.Value.Month == 6 ? (ACopiar.TotalAporteEmpleados / 3) * 2 : ACopiar.TotalAporteEmpleados;
      // Busco en _VDDetalle el periodo a modificar 
      mdlVDDetalle AModificar = _VDDetalle.FirstOrDefault(x => x.Id == VDId_Actual);

      //Comienzo a Copiar desde la Variable PeriodoACopiar a la variable PeriodoAModificar

      AModificar.TotalSueldoEmpleados = CalcularDifAguinaldo(Convert.ToDateTime(ACopiar.Periodo), ACopiar.TotalSueldoEmpleados, Convert.ToDateTime(AModificar.Periodo));
      AModificar.TotalSueldoSocios = CalcularDifAguinaldo(Convert.ToDateTime(ACopiar.Periodo), ACopiar.TotalSueldoSocios, Convert.ToDateTime(AModificar.Periodo));
      AModificar.TotalAporteEmpleados = CalcularDifAguinaldo(Convert.ToDateTime(ACopiar.Periodo), ACopiar.TotalAporteEmpleados, Convert.ToDateTime(AModificar.Periodo));
      AModificar.TotalAporteSocios = CalcularDifAguinaldo(Convert.ToDateTime(ACopiar.Periodo), ACopiar.TotalAporteSocios, Convert.ToDateTime(AModificar.Periodo));
      AModificar.DiasDeMora = mtdEmpresas.CalcularDias(Convert.ToDateTime(AModificar.Periodo), Convert.ToDateTime(msk_Vencimiento.Text));
      AModificar.CantidadEmpleados = ACopiar.CantidadEmpleados;
      AModificar.CantidadSocios = ACopiar.CantidadSocios;
      AModificar.DeudaGenerada = AModificar.TotalAporteSocios + AModificar.TotalAporteSocios;
      bool PagoConInteres = AModificar.DeudaGenerada - (AModificar.TotalAporteEmpleados + AModificar.TotalAporteSocios) > 0;
      AModificar.InteresGenerado = Math.Round(mtdEmpresas.CalcularInteres(null, Convert.ToDateTime(AModificar.Periodo), AModificar.DeudaGenerada, AModificar.DeudaGenerada, Convert.ToDateTime(msk_Vencimiento.Text), cbx_TipoDeInteres.SelectedIndex, Convert.ToDecimal(txt_InteresDiario.Text), PagoConInteres), 2);
      AModificar.Total = AModificar.DeudaGenerada + AModificar.InteresGenerado;
      Simulacion();

    }

    public decimal CalcularDifAguinaldo(DateTime PerioACopiar, decimal Importe, DateTime PeriodoAModificar)
    {
      if (PerioACopiar.Month == 12 || PerioACopiar.Month == 6)
      {
        Importe = (Importe / 3) * 2;
      }

      if (PeriodoAModificar.Month == 6 || PeriodoAModificar.Month == 12)
      {
        Importe = (Importe * Convert.ToDecimal("0.50")) + Importe;
      }
      return Importe;
    }

    private void dgv_VD_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void dgv_VD_SelectionChanged(object sender, EventArgs e)
    {
      TS_CopiarAnterior.Enabled = dgv_VD.CurrentRow.Index == 0 ? false : true;
      TS_CopiarSiguiente.Enabled = dgv_VD.CurrentRow.Index == dgv_VD.Rows.Count - 1 ? false : true;
      TS_IngresoManual.Enabled = Convert.ToInt32(dgv_VD.CurrentRow.Cells["PerNoDec"].Value) == 1 ? true : false;
      //Cargar_DDJJEmpleado();
    }


    private void dgv_DetallePeriodo_SelectionChanged(object sender, EventArgs e)
    {
      //MostrarDetalleDDJJ();
      //MostrarSueldoSegunEscala();
    }



    private void dgv_DetallePeriodo_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void TS_EliminarPeriodo_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Esta Seguro que desea ELIMINAR el Periodo seleccionado?", "ATENCION", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        int Index = dgv_VD.CurrentRow.Index;

        DateTime Periodo = Convert.ToDateTime(dgv_VD.CurrentRow.Cells["Periodo"].Value);
        int Rectificacion = Convert.ToInt32(dgv_VD.CurrentRow.Cells["Rectificacion"].Value);
        PeriodosEliminar.Add(_VDDetalle[Index].Id);
        _VDDetalle.RemoveAll(x => x.Periodo == Periodo && x.Rectificacion == Rectificacion);

        dgv_VD.DataSource = _VDDetalle.ToList();
        // dgv_VD.CurrentCell = Index == 0 ? dgv_VD.Rows[Index].Cells[0] : dgv_VD.Rows[Index - 1].Cells[0];
        dgv_VD.Rows[0].Selected = false;

        CalcularTotales();
        PintarPerNoDec();
      }
    }

    private void TS_CopiarAnterior_Click(object sender, EventArgs e)
    {
      CopiarPeriodo(false);
    }

    private void TS_CopiarSiguiente_Click(object sender, EventArgs e)
    {
      CopiarPeriodo(true);
    }

    private void TS_Recalcular_Click(object sender, EventArgs e)
    {
      Simulacion();
    }

    private void TS_IngresoManual_Click(object sender, EventArgs e)
    {

    }

    private void ToolStripBtn_GernerarTXT_Click(object sender, EventArgs e)
    {
      InsertPerNoInc();
    }

    private void TS_Grabar_Click(object sender, EventArgs e)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        foreach (var periodo in _VDDetalle)
        {
          var VDDetalle = context.VD_Detalle.Where(x => x.Id == periodo.Id).SingleOrDefault();

          DateTime? FechaDePago = null;

          if (periodo.FechaDePago != null)
          {
            FechaDePago = Convert.ToDateTime(periodo.FechaDePago);
          }

          // Pregunto por el Periodo.Id == 0 por que si es asi entonces es un perido para insertar

          if (periodo.Id == 0)
          {
            VD_Detalle VDD = new VD_Detalle
            {
              VDInspectorId = _VDId,
              Periodo = Convert.ToDateTime(periodo.Periodo),
              Rectificacion = periodo.Rectificacion,
              CantidadEmpleados = (int)periodo.CantidadEmpleados,
              CantidadSocios = (int)periodo.CantidadSocios,
              TotalSueldoEmpleados = periodo.TotalSueldoEmpleados,
              TotalSueldoSocios = periodo.TotalSueldoSocios,
              TotalAporteEmpleados = periodo.TotalAporteEmpleados,
              TotalAporteSocios = periodo.TotalAporteSocios,
              FechaDePago = FechaDePago, //periodo.FechaDePago,
              ImporteDepositado = periodo.ImporteDepositado,
              DiasDeMora = periodo.DiasDeMora,
              DeudaGenerada = periodo.DeudaGenerada,
              InteresGenerado = periodo.InteresGenerado,
              Total = periodo.Total,
              PerNoDec = periodo.PerNoDec,
              ActaId = 0,
              NumeroDeActa = 0,
              Estado = 0
            };
            context.VD_Detalle.InsertOnSubmit(VDD);
            context.SubmitChanges();
          }
          else
          {
            VDDetalle.Periodo = Convert.ToDateTime(periodo.Periodo);
            VDDetalle.Rectificacion = periodo.Rectificacion;
            VDDetalle.CantidadEmpleados = periodo.CantidadEmpleados;
            VDDetalle.CantidadSocios = periodo.CantidadSocios;
            VDDetalle.TotalSueldoEmpleados = periodo.TotalSueldoEmpleados;
            VDDetalle.TotalSueldoSocios = periodo.TotalSueldoSocios;
            VDDetalle.TotalAporteEmpleados = periodo.TotalAporteEmpleados;
            VDDetalle.TotalAporteSocios = periodo.TotalAporteSocios;
            VDDetalle.FechaDePago = FechaDePago;//periodo.FechaDePago == null ? null : Convert.ToDateTime(periodo.FechaDePago);
            VDDetalle.ImporteDepositado = periodo.ImporteDepositado;
            VDDetalle.DiasDeMora = periodo.DiasDeMora;
            VDDetalle.DeudaGenerada = periodo.DeudaGenerada;
            VDDetalle.InteresGenerado = periodo.InteresGenerado;
            VDDetalle.Total = periodo.Total;
            VDDetalle.PerNoDec = periodo.PerNoDec;
            VDDetalle.ActaId = 0;
            VDDetalle.NumeroDeActa = 0;
            VDDetalle.Estado = 0;
            context.SubmitChanges();
          }
        };

        // Actualizo la tabla de VD_Inspector
        var UpdateVD = (from a in context.VD_Inspector where a.Id == _VDId select a).SingleOrDefault();
        UpdateVD.InspectorId = (Int32)cbx_Inspectores.SelectedValue;
        UpdateVD.Desde = Convert.ToDateTime(msk_Desde.Text);
        UpdateVD.Hasta = _VDDetalle.Max(x => x.Periodo).Value;
        UpdateVD.FechaVenc = Convert.ToDateTime(msk_Vencimiento.Text);
        UpdateVD.TipoInteres = cbx_TipoDeInteres.SelectedIndex;
        UpdateVD.InteresMensual = Convert.ToDecimal(txt_Interes.Text);
        UpdateVD.InteresDiario = Convert.ToDecimal(txt_InteresDiario.Text);
        UpdateVD.Capital = Convert.ToDecimal(txt_Deuda.Text);         //Math.Round(_ddjj.Sum(x => x.Capital), 2)
        UpdateVD.Interes = Convert.ToDecimal(txt_TotalInteres.Text);
        UpdateVD.Total = Convert.ToDecimal(txt_Total.Text);
        context.SubmitChanges();

        PlanDePagoABM();
      }

    }

    private void btn_ImprimirDeuda_Click(object sender, EventArgs e)
    {

    }

    private void Txt_Anticipo_TextChanged(object sender, EventArgs e)
    {
      //  if (string.IsNullOrEmpty(Txt_Anticipo.Text))
      //  {
      //    Txt_Anticipo.Text = "0.00";
      //  }
      //  else
      //  {
      //    Txt_Anticipo.Text = Convert.ToDecimal(Txt_Anticipo.Text).ToString("N2");
      //  }
    }

    private void Cbx_CantidadDeCuotas_SelectedIndexChanged(object sender, EventArgs e)
    {
      MostrarPlanDePago();
      //CalcularCuota();
    }

    private void CalcularCuota()
    {
      Txt_ImporteDeCuota.Text = (Convert.ToDecimal(Txt_SubTotal.Text) / (Cbx_CantidadDeCuotas.SelectedIndex + 1)).ToString("N2");
    }

    private void TSB_Calcular_Click(object sender, EventArgs e)
    {
      MostrarPlanDePago();
      //CargarDgv_PlanDePago();
    }

    private void CargarDgv_PlanDePago()
    {
      // List<MdlPlanDePagoDetalle> PlanDePagoDGV = new List<MdlPlanDePagoDetalle>();
      _PlanDePagoDGV.Clear();
      dgv_PlanDePagos.DataSource = _PlanDePagoDGV;
      DateTime FechaVenc = Dtp_VencCuota.Value;

      if (Convert.ToDecimal(Txt_Anticipo.Text) > 0)
      {
        _PlanDePagoDGV.Add(new MdlPlanDePagoDetalle
        {
          Cuota = 0,
          FechaDeVenc = Dtp_VencAnticipo.Value.Date,
          ImporteDeCuota = Convert.ToDecimal(Txt_Anticipo.Text)
        });
      }

      for (int i = 0; i < Cbx_CantidadDeCuotas.SelectedIndex + 1; i++)
      {
        MdlPlanDePagoDetalle Insert = new MdlPlanDePagoDetalle
        {
          Cuota = i + 1,
          FechaDeVenc = FechaVenc,
          ImporteDeCuota = Convert.ToDecimal(Txt_ImporteDeCuota.Text)
        };
        _PlanDePagoDGV.Add(Insert);
        FechaVenc = FechaVenc.AddMonths(1);
      }
      dgv_PlanDePagos.DataSource = _PlanDePagoDGV.ToList();
    }

    private void TSB_Confirmar_Click(object sender, EventArgs e)
    {
      PlanDePagoABM();
    }

    private void PlanDePagoABM()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var PP = context.VD_PlanesDePago.Where(x => x.NumeroVD == _NumeroVD).Select(x => x.Numero);

        if (PP.Count() == 0)
        {
          GuardarPlanDePago();
        }
        else
        {
          ModificarPlanDePago();
        }
      }
    }

    private void GuardarPlanDePago()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        VD_PlanesDePago PP = new VD_PlanesDePago
        {
          Fecha = DateTime.Now,
          Numero = context.VD_PlanesDePago.Count() == 0 ? 1 : context.VD_PlanesDePago.Max(x => x.Numero) + 1,
          Deuda = Convert.ToDecimal(txt_DeudaInicial.Text),
          Ajuste = Convert.ToDecimal(Txt_Ajuste.Text),
          DeudaConAjuste = Convert.ToDecimal(Txt_DeudaConAjuste.Text),
          InteresFinanciacionPorcentaje = Convert.ToDecimal(Txt_InteresDeFinanciacion.Text),
          InteresFinanciacionImporte = Convert.ToDecimal(Txt_ImporteInteresDeFinanciacion.Text),
          DeudaConInteres = Convert.ToDecimal(Txt_TotalDeuda.Text),
          Anticipo = Convert.ToDecimal(Txt_Anticipo.Text),
          AnticipoVencimiento = Convert.ToDateTime(Dtp_VencAnticipo.Value.Date),
          DeudaAFinanciar = Convert.ToDecimal(Txt_SubTotal.Text),
          Cuotas = string.IsNullOrWhiteSpace(Cbx_CantidadDeCuotas.Text) ? 1 : Convert.ToInt16(Cbx_CantidadDeCuotas.Text),
          CuotasImporte = Convert.ToDecimal(Txt_ImporteDeCuota.Text),
          CuotaVencimiento = Convert.ToDateTime(Dtp_VencCuota.Value.Date),
          Comentario = Txt_Comentario.Text.Trim(),
          Acta = _NroDeActa,
          UserId = _UsuarioId,
          NumeroVD = _NumeroVD
        };
        context.VD_PlanesDePago.InsertOnSubmit(PP);
        context.SubmitChanges();
        MessageBox.Show("Ya guardaste el plan de pago.");
      }
    }

    private void ModificarPlanDePago()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var PlanP = (from a in context.VD_PlanesDePago.Where(x => x.NumeroVD == _NumeroVD)
                     select a).FirstOrDefault();
        PlanP.Deuda = Convert.ToDecimal(txt_DeudaInicial.Text.Trim());
        PlanP.Ajuste = Convert.ToDecimal(Txt_Ajuste.Text);
        PlanP.DeudaConAjuste = Convert.ToDecimal(Txt_DeudaConAjuste.Text);
        PlanP.InteresFinanciacionPorcentaje = Convert.ToDecimal(Txt_InteresDeFinanciacion.Text);
        PlanP.InteresFinanciacionImporte = Convert.ToDecimal(Txt_ImporteInteresDeFinanciacion.Text);
        PlanP.DeudaConInteres = Convert.ToDecimal(Txt_TotalDeuda.Text);
        PlanP.Anticipo = Convert.ToDecimal(Txt_Anticipo.Text);
        PlanP.AnticipoVencimiento = Convert.ToDateTime(Dtp_VencAnticipo.Value.Date);
        PlanP.DeudaAFinanciar = Convert.ToDecimal(Txt_SubTotal.Text);
        PlanP.Cuotas = Convert.ToInt16(Cbx_CantidadDeCuotas.Text);
        PlanP.CuotasImporte = Convert.ToDecimal(Txt_ImporteDeCuota.Text);
        PlanP.CuotaVencimiento = Convert.ToDateTime(Dtp_VencCuota.Value.Date);
        PlanP.Comentario = Txt_Comentario.Text.Trim();
        PlanP.Acta = _NroDeActa;
        PlanP.UserId = _UsuarioId;
        PlanP.NumeroVD = _NumeroVD;

        context.SubmitChanges();
        MessageBox.Show("Plan de Pago Modificado");
      }
    }

    private void EliminarPeriodo()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        foreach (var item in PeriodosEliminar)
        {
          var a = context.VD_Detalle.Where(x => x.Id == item).SingleOrDefault();
          context.VD_Detalle.DeleteOnSubmit(a);
          context.SubmitChanges();
        }
        PeriodosEliminar.Clear();
      }
      MostrarPeriodosNoIncorporados();

    }
    private void Txt_Ajuste_Leave(object sender, EventArgs e)
    {
      if (string.IsNullOrWhiteSpace(Txt_Ajuste.Text))
      {
        Txt_Ajuste.Text = "0.00";
      }
      else
      {
        Txt_Ajuste.Text = (Convert.ToDecimal(Txt_Ajuste.Text)).ToString("N2");
      }
    }

    private void Txt_Ajuste_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        if (string.IsNullOrEmpty(Txt_Ajuste.Text))
        {
          Txt_Ajuste.Text = "0.00";
        }
        else
        {
          Txt_Ajuste.Text = Convert.ToDecimal(Txt_Ajuste.Text).ToString("N2");
        }

        MostrarPlanDePago();
        Txt_Anticipo.Focus();

      }
    }

    private void Txt_Anticipo_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        if (string.IsNullOrEmpty(Txt_Anticipo.Text))
        {
          Txt_Anticipo.Text = "0.00";
        }
        else
        {
          Txt_Anticipo.Text = Convert.ToDecimal(Txt_Anticipo.Text).ToString("N2");
        }
        MostrarPlanDePago();
        Dtp_VencAnticipo.Focus();

        //SendKeys.Send("{F4}");

      }
    }

    private void Txt_InteresDeFinanciacion_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        if (string.IsNullOrEmpty(Txt_InteresDeFinanciacion.Text))
        {
          Txt_InteresDeFinanciacion.Text = "0.00";
        }
        else
        {
          Txt_InteresDeFinanciacion.Text = Convert.ToDecimal(Txt_InteresDeFinanciacion.Text).ToString("N2");
        }

        MostrarPlanDePago();
        Cbx_CantidadDeCuotas.Focus();
        Cbx_CantidadDeCuotas.DroppedDown = true;
        //SendKeys.Send("F4");
      }
    }

    private void Dtp_VencAnticipo_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        MostrarPlanDePago();
        Txt_InteresDeFinanciacion.Focus();
      }
    }

    private void Cbx_CantidadDeCuotas_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        MostrarPlanDePago();
        Dtp_VencCuota.Focus();
      }
    }

    private void Dtp_VencCuota_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        MostrarPlanDePago();
      }
    }

    private void TS_ImprimirVD_Click(object sender, EventArgs e)
    {
      ImprimirVD();
    }

    private void ImprimirVD()
    {

      DS_cupones ds = new DS_cupones();
      DataTable dt_ActasDetalle = ds.ActasDetalle;

      dt_ActasDetalle.Clear();
      int Color = 0; ;
      foreach (var periodo in _VDDetalle)//_ddjj.Where(x => x.Acta == ""))
      {
        Color += 1;
        DataRow row = dt_ActasDetalle.NewRow();
        row["NumeroDeActa"] = 0;
        row["NroVD"] = _NumeroVD.ToString("N0");
        row["Periodo"] = periodo.Periodo;
        row["CantidadDeEmpleados"] = periodo.CantidadEmpleados;
        row["CantidadSocios"] = periodo.CantidadSocios;
        row["TotalSueldoEmpleados"] = periodo.TotalSueldoEmpleados;
        row["TotalSueldoSocios"] = periodo.TotalSueldoSocios;
        row["TotalAporteEmpleados"] = periodo.TotalAporteEmpleados;
        row["TotalAporteSocios"] = periodo.TotalAporteSocios;
        row["FechaDePago"] = periodo.FechaDePago == null ? "" : periodo.FechaDePago.Value.Date.ToShortDateString();
        row["ImporteDepositado"] = periodo.ImporteDepositado;
        row["DiasDeMora"] = periodo.DiasDeMora;
        row["DeudaGenerada"] = periodo.DeudaGenerada;
        row["InteresGenerado"] = periodo.InteresGenerado;
        row["Total"] = periodo.Total;
        row["Color"] = Color;
        row["Logo"] = mtdConvertirImagen.ImageToByteArray(Image.FromFile("C:\\SEC_Gestion\\Imagen\\Logo_reporte.jpg"));
        dt_ActasDetalle.Rows.Add(row);
      }

      Empresa empresa = mtdEmpresas.GetEmpresa(txt_CUIT.Text);

      reportes formReporte = new reportes();

      formReporte.dt = dt_ActasDetalle;
      formReporte.dt2 = mtdFilial.Get_DatosFilial();
      formReporte.dt3 = PlanDePagoCabecera();

      formReporte.Parametro1 = empresa.MAEEMP_RAZSOC.Trim();
      formReporte.Parametro2 = empresa.MEEMP_CUIT_STR;
      formReporte.Parametro3 = "-";
      formReporte.Parametro4 = txt_Deuda.Text;//Math.Round(_ddjj.Where(x => x.Acta == "").Sum(x => x.Capital), 2).ToString("N2");
      formReporte.Parametro5 = txt_TotalInteres.Text;//Math.Round(_ddjj.Where(x => x.Acta == "").Sum(x => x.Interes), 2).ToString("N2");
      formReporte.Parametro6 = txt_Total.Text;//Math.Round(_ddjj.Where(x => x.Acta == "").Sum(x => x.Total), 2).ToString("N2");
      formReporte.Parametro8 = " ";
      formReporte.Parametro9 = msk_Vencimiento.Text;
      formReporte.Parametro10 = txt_PerNoDec.Text;
      formReporte.Parametro11 = txt_Domicilio.Text;

      formReporte.NombreDelReporte = "entrega_cupones.Reportes.rpt_VerificacionDeDeuda.rdlc";
      formReporte.Show();
    }

    private DataTable PlanDePagoCabecera()
    {

      DS_cupones Ds = new DS_cupones();

      DataTable Dt = Ds.PlanDePagoCabecera;
      DataRow Dr = Dt.NewRow();
      Dr["DeudaInicial"] = txt_DeudaInicial.Text;
      Dr["Ajuste"] = Txt_Ajuste.Text;
      Dr["DeudaInicalConAjuste"] = Txt_DeudaConAjuste.Text;
      Dr["Anticipo"] = Txt_Anticipo.Text;
      Dr["VencAnticipo"] = Dtp_VencAnticipo.Value.ToString("d");
      Dr["SubTotal"] = Txt_SubTotal.Text;
      Dr["InteresDeFinanc"] = Txt_InteresDeFinanciacion.Text;
      Dr["Cuotas"] = Cbx_CantidadDeCuotas.Text;
      Dr["VencCuotas"] = Dtp_VencCuota.Value.Date.ToString("d");
      Dr["ImporteDeInteres"] = Txt_ImporteInteresDeFinanciacion.Text;
      Dr["TotalDeuda"] = Txt_TotalDeuda.Text;
      Dr["ImporteDeCuota"] = Txt_ImporteDeCuota.Text;
      Dr["Comentario"] = Txt_Comentario.Text;
      Dr["Inspector"] = cbx_Inspectores.Text;
      Dr["NumeroVD"] = _NumeroVD.ToString();
      Dr["Usuario"] = _Usuario; ;
      Dt.Rows.Add(Dr);
      return Dt;
    }

    private void TSB_ImprimirPlanDePago_Click(object sender, EventArgs e)
    {
      ImprimirPlanDePago();
    }

    private void ImprimirPlanDePago()
    {
      mtdCobranzas.ImprimirPlanDePago2(_NroDePlanDePago, PlanDePagoCabecera(), _PlanDePagoDGV, txt_BuscarEmpesa.Text, txt_CUIT.Text, txt_Domicilio.Text, cbx_Inspectores.Text, txt_Total.Text, Txt_TotalDeuda.Text.ToString(), "");
    }

    private void Dtp_VencAnticipo_ValueChanged(object sender, EventArgs e)
    {
      MostrarPlanDePago();
    }

    private void Dtp_VencCuota_ValueChanged(object sender, EventArgs e)
    {
      MostrarPlanDePago();
    }

    private void Txt_Anticipo_Leave(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(Txt_Anticipo.Text))
      {
        Txt_Anticipo.Text = "0.00";
      }
      else
      {
        Txt_Anticipo.Text = Convert.ToDecimal(Txt_Anticipo.Text).ToString("N2");
      }
    }

    private void Txt_Ajuste_TextChanged(object sender, EventArgs e)
    {
      //if (string.IsNullOrWhiteSpace(Txt_Ajuste.Text))
      //{
      //  Txt_Ajuste.Text = "0.00";
      //}
      //else
      //{
      //  Txt_Ajuste.Text = (Convert.ToDecimal(Txt_Ajuste.Text)).ToString("N2");
      //}
    }

    private void TS_EmitirActa_Click(object sender, EventArgs e)
    {
      // _VDDetalle.Where(x => x.NumeroDeActa != "");

      EmitirActa();
    }

    private void EmitirActa()
    {
      _NroDeActa =
        mtdActas.GuardarActaCabecera2
          (
          _VDDetalle,
          DateTime.Now,
          Convert.ToDateTime(msk_Desde.Text),
          Convert.ToDateTime(msk_Hasta.Text),
          Convert.ToDateTime(msk_Vencimiento.Text),
          0,
          txt_CUIT.Text,
          0,
          Convert.ToDecimal(txt_Interes.Text),
          Convert.ToDecimal(txt_InteresDiario.Text),
          (int)cbx_Inspectores.SelectedValue,
          Convert.ToDecimal(txt_Deuda.Text),
          Convert.ToDecimal(txt_TotalInteres.Text),
          Convert.ToDecimal(txt_Total.Text),
          _NroDePlanDePago,
          _NumeroVD
          )
          ;


      mtdCobranzas.AsentarPlan2(txt_CUIT.Text, _NroDePlanDePago);
      //mtdCobranzas.CargarPlanDetalle2(_PlanDePagoDGV, _NroDePlanDePago);
      MessageBox.Show("Acta N° " + _NroDeActa.ToString() + " Generada con EXITO. & _" +
        "Plande Pago N° " + _NroDePlanDePago.ToString() + " Generado con EXITO");
    }

    private void label29_Click(object sender, EventArgs e)
    {

    }

    private void dgv_VD_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
      //var obj = _VDDetalle[e.RowIndex];
      //obj.TotalSueldoEmpleados = (decimal) dgv_VD.Rows[e.RowIndex].Cells["TotalSueldoEmpleado"].Value;
      //_VDDetalle[e.RowIndex] = obj;
      Simulacion();
    }

        private void TS_DetallePeriodo_Click(object sender, EventArgs e)
        {

        }
    }
}

