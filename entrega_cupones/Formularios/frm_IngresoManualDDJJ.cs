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
using Org.BouncyCastle.Asn1.Mozilla;

namespace entrega_cupones.Formularios
{
  public partial class frm_IngresoManualDDJJ : Form
  {
    public DateTime _FechaDeVencimiento;
    public int _TipoDeInteres;
    public decimal _TazaInteres;
    public decimal _VarSueldo;
    public decimal _VarSueldoJC;
    public decimal _VarSueldoJP;

    List<mdlVDDetalle> _CargaManual = new List<mdlVDDetalle>();
    public int _DiasDeMora;
    public DateTime _Periodo;

    public decimal _SueldoBase;
    public decimal _PorcentajeDescuento;
    public decimal _AporteLeyJC;
    public decimal _AporteSocioJC;
    public decimal _AporteLeyJP;
    public decimal _AporteSocioJP;
    public decimal _Intereses;
    public int _CantEmpJorComp;
    public int _CantEmpJorPar;
    public int _CantSocJorComp;
    public int _CantSocJorPar;
    public decimal _Subtotal;


    public decimal _TotalSueldosLey931;
    public decimal _AporteLeyJC931;
    public decimal _TotalSueldosSocio931;
    public decimal _AporteSocioJC931;
    public decimal _Intereses931;
    public int _CantEmp931;
    public int _CantSoc931;
    public decimal _Subtotal931;

    public frm_IngresoManualDDJJ()
    {
      InitializeComponent();
    }

    private void frm_IngresoManualDDJJ_Load(object sender, EventArgs e)
    {
      _Periodo = Convert.ToDateTime(txt_Periodo.Text);
      _DiasDeMora = mtdFuncUtiles.CalcularDias(_Periodo.AddMonths(1).AddDays(14), _FechaDeVencimiento);
      txt_DiasDeMora.Text = _DiasDeMora.ToString("N0");
      _PorcentajeDescuento = Convert.ToDecimal("0.02");

    }

    private void EnviarOjeto()
    {
      bool ConSueldoBase = TB_IngresoManual.SelectedTab.Name == "Tp_SueldoBase";

      mdlVDDetalle Insert = new mdlVDDetalle
      {
        Periodo = Convert.ToDateTime(txt_Periodo.Text),
        Rectificacion = 0,
        TotalSueldoEmpleados = ConSueldoBase ? (_AporteLeyJC + _AporteLeyJP) / _PorcentajeDescuento : _TotalSueldosLey931, //Convert.ToDecimal(Txt_DescLeyJorComp.Text) / Porcentaje : Convert.ToDecimal(Txt_DescuentoLey931.Text),
        TotalAporteEmpleados = ConSueldoBase ? (_AporteLeyJC + _AporteLeyJP) : _AporteLeyJC931,
        TotalSueldoSocios = ConSueldoBase ? (_AporteSocioJC + _AporteSocioJP) / _PorcentajeDescuento : _TotalSueldosSocio931,
        TotalAporteSocios = ConSueldoBase ? (_AporteSocioJC + _AporteSocioJP) : _AporteSocioJC931,
        ImporteDepositado = 0,
        DiasDeMora = _DiasDeMora,
        CantidadEmpleados = ConSueldoBase ? (_CantEmpJorComp + _CantEmpJorPar) : _CantEmp931,
        CantidadSocios = ConSueldoBase ? (_CantSocJorComp + _CantSocJorPar) : _CantSoc931,
        DeudaGenerada = ConSueldoBase ? (_AporteLeyJC + _AporteSocioJC + _AporteLeyJP + _AporteSocioJP) : (_AporteLeyJC931 + _AporteSocioJC931),
        InteresGenerado = ConSueldoBase ? _Intereses : _Intereses931,
        Total = ConSueldoBase ? _Subtotal + _Intereses : _Subtotal931 + _Intereses931,
        PerNoDec = 0
      };

      _CargaManual.Add(Insert);
      VerificarDeuda formverificardeuda = Owner as VerificarDeuda;
      formverificardeuda._CargaManual = _CargaManual;
      formverificardeuda._Cancelado = false;
    }

    private void CalcularDeudaSueldoBase()
    {
      _SueldoBase = Convert.ToDecimal(string.IsNullOrWhiteSpace(Txt_SueldoBase.Text) ? "0" : Txt_SueldoBase.Text);

      _CantEmpJorComp = Convert.ToInt32(string.IsNullOrWhiteSpace(Txt_CantEmpJorComp.Text) ? "0" : Txt_CantEmpJorComp.Text);

      _AporteLeyJC = _CantEmpJorComp * _SueldoBase * _PorcentajeDescuento;
      Txt_DescLeyJorComp.Text = _AporteLeyJC.ToString("N2");

      _CantSocJorComp = Convert.ToInt32(string.IsNullOrWhiteSpace(Txt_CantSocJorComp.Text) ? "0" : Txt_CantSocJorComp.Text);
      _AporteSocioJC = (_CantSocJorComp * _SueldoBase) * _PorcentajeDescuento;
      Txt_DescSocioJorComp.Text = _AporteSocioJC.ToString("N2");

      _CantEmpJorPar = Convert.ToInt32(string.IsNullOrWhiteSpace(Txt_CantEmpJorPar.Text) ? "0" : Txt_CantEmpJorPar.Text);

      _AporteLeyJP = (_CantEmpJorPar * _SueldoBase / 2) * _PorcentajeDescuento;
      Txt_DescLeyJorPar.Text = _AporteLeyJP.ToString("N2");

      _CantSocJorPar = Convert.ToInt32(string.IsNullOrWhiteSpace(Txt_CantSocJorPar.Text) ? "0" : Txt_CantSocJorPar.Text);
      _AporteSocioJP = (_CantSocJorPar * _SueldoBase / 2) * _PorcentajeDescuento;
      Txt_DescSocioJorPar.Text = _AporteSocioJP.ToString("N2");

      DateTime Periodo = Convert.ToDateTime(txt_Periodo.Text);
      txt_DiasDeMora.Text = mtdFuncUtiles.CalcularDias(Periodo.AddMonths(1).AddDays(14), _FechaDeVencimiento).ToString();

      _Subtotal = (_AporteLeyJC + _AporteSocioJC + _AporteLeyJP + _AporteSocioJP);

      Txt_SubTotalConSueldoBase.Text = _Subtotal.ToString("N2");

      _Intereses = mtdIntereses.CalcularInteres(null, Periodo.AddMonths(1).AddDays(14), Convert.ToDecimal(string.IsNullOrWhiteSpace(Txt_SubTotalConSueldoBase.Text) ? "0" : Txt_SubTotalConSueldoBase.Text), _FechaDeVencimiento, _TipoDeInteres, _TazaInteres);

      Txt_InteresConSueldoBase.Text = _Intereses.ToString("N2");

      Txt_TotalAportesConSueldoBase.Text = (_AporteLeyJC + _AporteSocioJC + _AporteLeyJP + _AporteSocioJP + _Intereses).ToString("N2");

    }

    private void Txt_SueldoBase_TextChanged(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(Txt_SueldoBase.Text))
      {
        CalcularDeudaSueldoBase();
      }

    }

    private void Txt_CantEmpJorComp_TextChanged(object sender, EventArgs e)
    {
      if (!string.IsNullOrWhiteSpace(Txt_SueldoBase.Text))
      {
        CalcularDeudaSueldoBase();

      }
    }

    private void Txt_CantSocJorComp_TextChanged(object sender, EventArgs e)
    {
      CalcularDeudaSueldoBase();
    }

    private void Txt_CantEmpJorPar_TextChanged(object sender, EventArgs e)
    {
      CalcularDeudaSueldoBase();
    }

    private void Txt_CantSocJorPar_TextChanged(object sender, EventArgs e)
    {
      CalcularDeudaSueldoBase();
    }

    private void CalcularDeuda931()
    {
      _TotalSueldosLey931 = Convert.ToDecimal(string.IsNullOrWhiteSpace(Txt_SueldosLey931.Text) ? "0" : Txt_SueldosLey931.Text);
      _AporteLeyJC931 = _TotalSueldosLey931 * _PorcentajeDescuento;
      Txt_DescuentoLey931.Text = _AporteLeyJC931.ToString("N2");
      _CantEmp931 = Convert.ToInt32(string.IsNullOrWhiteSpace(Txt_CantidadEmpleados931.Text) ? "0" : Txt_CantidadEmpleados931.Text);
      _CantSoc931 = Convert.ToInt32(string.IsNullOrWhiteSpace(Txt_CantidadSocioss931.Text) ? "0" : Txt_CantidadSocioss931.Text);

      _TotalSueldosSocio931 = (Convert.ToDecimal(string.IsNullOrWhiteSpace(Txt_SueldosSocio931.Text) ? "0" : Txt_SueldosSocio931.Text));
      _AporteSocioJC931 = _TotalSueldosSocio931 * _PorcentajeDescuento;
      Txt_DescuentoSocio931.Text = _AporteSocioJC931.ToString("N2");

      _Subtotal931 = (_AporteLeyJC931 + _AporteSocioJC931);

      Txt_SubTotal931.Text = _Subtotal931.ToString("N2");

      _Intereses931 = mtdIntereses.CalcularInteres(null, _Periodo.AddMonths(1).AddDays(14), Convert.ToDecimal(string.IsNullOrWhiteSpace(Txt_SubTotal931.Text) ? "0" : Txt_SubTotal931.Text), _FechaDeVencimiento, _TipoDeInteres, _TazaInteres);

      Txt_Interes931.Text = _Intereses931.ToString("N2");

      Txt_Total931.Text = (_AporteLeyJC931 + _AporteSocioJC931 + _Intereses931).ToString("N2");
    }

    private void Txt_SueldosLey931_TextChanged(object sender, EventArgs e)
    {
      CalcularDeuda931();
    }

    private void Txt_SueldosSocio931_TextChanged(object sender, EventArgs e)
    {
      CalcularDeuda931();
    }

    private void Btn_Cancelar_Click(object sender, EventArgs e)
    {
      VerificarDeuda formverificardeuda = Owner as VerificarDeuda;
      formverificardeuda._Cancelado = true;
      Close();
    }

    private void btn_Confirmar_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Ha verificado correctamente los datos ingresados?  De no hacerlo presione CANCELAR y verifique nuevamente.", "ATENCION", MessageBoxButtons.OKCancel) == DialogResult.OK)
      {
        EnviarOjeto();
        Close();
      }
    }
  }
}
