using entrega_cupones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Metodos
{
  class mtdVDDetalle
  {
    public static void Insert_VDDetalle(List<EstadoDDJJ> ddjjt, int NroVD, bool ParaInsertar)
    {
      foreach (var periodo in ddjjt)
      {
        if (ParaInsertar)
        {
          InsertVDDetalle(periodo, NroVD);
        }
        else
        {
          if (periodo.VerifDeuda == "")
          {
            InsertVDDetalle(periodo, NroVD);
          }
          else
          {
            UpdateVDDetalle(periodo, NroVD, periodo.Periodo, periodo.Rectificacion, Convert.ToDateTime(periodo.FechaDePago));
          }
        }
      }
    }

    public static void InsertVDDetalle(EstadoDDJJ periodo, int NroVD)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        VD_Detalle VDDetalle = new VD_Detalle
        {
          VDInspectorId = NroVD,
          Periodo = periodo.Periodo,
          Rectificacion = periodo.Rectificacion,
          CantidadEmpleados = periodo.Empleados,
          CantidadSocios = periodo.Socios,
          TotalSueldoEmpleados = periodo.TotalSueldoEmpleados,
          TotalSueldoSocios = periodo.TotalSueldoSocios,
          TotalAporteEmpleados = periodo.AporteLey,
          TotalAporteSocios = periodo.AporteSocio,
          FechaDePago = periodo.FechaDePago,
          ImporteDepositado = periodo.ImporteDepositado,
          DiasDeMora = periodo.DiasDeMora,
          DeudaGenerada = periodo.Capital,
          InteresGenerado = periodo.Interes,
          Total = periodo.Total,
          PerNoDec = periodo.PerNoDec,
          ActaId = 0,
          NumeroDeActa = 0,
          Estado = 0
        };

        context.VD_Detalle.InsertOnSubmit(VDDetalle);
        context.SubmitChanges();
      }
    }

    public static void UpdateVDDetalle(EstadoDDJJ ObjPeriodo, int VD_CabeceraId, DateTime Periodo, int Rectificacion, DateTime FechaDePago)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var PeriodoDeVDDetalle = context.VD_Detalle.Where(x => x.VDInspectorId == VD_CabeceraId && x.Periodo == Periodo && x.Rectificacion == Rectificacion && x.FechaDePago == FechaDePago).Single();
        if (PeriodoDeVDDetalle != null)
        {
          PeriodoDeVDDetalle.CantidadEmpleados = ObjPeriodo.Empleados;
          PeriodoDeVDDetalle.CantidadSocios = ObjPeriodo.Socios;
          PeriodoDeVDDetalle.TotalSueldoEmpleados = ObjPeriodo.TotalSueldoEmpleados;
          PeriodoDeVDDetalle.TotalSueldoSocios = ObjPeriodo.TotalSueldoSocios;
          PeriodoDeVDDetalle.TotalAporteEmpleados = ObjPeriodo.AporteLey;
          PeriodoDeVDDetalle.TotalAporteSocios = ObjPeriodo.AporteSocio;
          PeriodoDeVDDetalle.FechaDePago = Convert.ToDateTime(ObjPeriodo.FechaDePago);
          PeriodoDeVDDetalle.ImporteDepositado = ObjPeriodo.ImporteDepositado;
          PeriodoDeVDDetalle.DiasDeMora = ObjPeriodo.DiasDeMora;
          PeriodoDeVDDetalle.DeudaGenerada = ObjPeriodo.Capital;
          PeriodoDeVDDetalle.InteresGenerado = ObjPeriodo.Interes;
          PeriodoDeVDDetalle.Total = ObjPeriodo.Total;
          PeriodoDeVDDetalle.PerNoDec = ObjPeriodo.PerNoDec;
          context.SubmitChanges();
        }
      }
    }

    public static List<mdlVDDetalle> Get_VDD(int VDId)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var VD = from a in context.VD_Detalle
                 where a.VDInspectorId == VDId
                 select new mdlVDDetalle
                 {
                   Id = a.Id,
                   VDInspectorId = (int)a.VDInspectorId,
                   Periodo = a.Periodo,
                   Rectificacion = (int)a.Rectificacion,
                   CantidadEmpleados = a.CantidadEmpleados,
                   CantidadSocios = a.CantidadSocios,
                   TotalSueldoEmpleados = a.TotalSueldoEmpleados,
                   TotalSueldoSocios = a.TotalSueldoSocios,
                   TotalAporteEmpleados = a.TotalAporteEmpleados,
                   TotalAporteSocios = a.TotalAporteSocios,
                   FechaDePago = a.FechaDePago,
                   ImporteDepositado = a.ImporteDepositado,
                   DiasDeMora = a.DiasDeMora,
                   DeudaGenerada = a.DeudaGenerada,
                   InteresGenerado = a.InteresGenerado,
                   Total = a.Total,
                   ActaId = a.ActaId,
                   NumeroDeActa = a.NumeroDeActa,
                   Estado = (int)a.Estado
                 };
        return VD.ToList();
      }
    }



    public static List<mdlVDDetalle> VD_Simulacion(List<mdlVDDetalle> VD_Detalle, string cuit, DateTime desde, DateTime hasta, DateTime FechaVencimiento, int TipoInteres, decimal TazaInteres, int VDId)
    {
      foreach (mdlVDDetalle vD in VD_Detalle)
      {
        vD.Periodo = Convert.ToDateTime(vD.Periodo); // Convert.ToDateTime(row.Periodo),
        vD.Rectificacion = (int)vD.Rectificacion;
        vD.TotalAporteEmpleados = (decimal)vD.TotalSueldoEmpleados * Convert.ToDecimal("0.02"); //vD.TotalAporteEmpleados;
        vD.TotalAporteSocios = (decimal)vD.TotalSueldoSocios * Convert.ToDecimal("0.02");//vD.TotalAporteSocios;
        vD.TotalSueldoEmpleados = (decimal)vD.TotalSueldoEmpleados; /*.titem1 / Convert.ToDecimal(0.02)*/
        vD.TotalSueldoSocios = (decimal)vD.TotalSueldoSocios; //.titem2 / Convert.ToDecimal(0.02),
        vD.FechaDePago = vD.FechaDePago == null ? null : vD.FechaDePago; //.fpago == null ? null : row.fpago,
        vD.ImporteDepositado = (decimal)vD.ImporteDepositado; //row.impban1,
        vD.CantidadEmpleados = vD.CantidadEmpleados;//context.ddjj.Where(x => x.CUIT_STR == cuit && (x.periodo == row.periodo) && (x.rect == row.rect)).Count(),
        vD.CantidadSocios = vD.CantidadSocios;//context.ddjj.Where(x => x.CUIT_STR == cuit && (x.periodo == row.periodo) && x.rect == row.rect && x.item2 == true).Count(),

        int DiasDeMora = CalcularDias(Convert.ToDateTime(vD.Periodo), vD.FechaDePago == null ? FechaVencimiento : Convert.ToDateTime(vD.FechaDePago)); //Convert.ToDecimal(0.99)

        decimal Capital = CalcularCapital(vD.ImporteDepositado, vD.TotalAporteEmpleados, vD.TotalAporteSocios,
                 Convert.ToDateTime(vD.FechaDePago), FechaVencimiento, Convert.ToDateTime(vD.Periodo),
                 TipoInteres, TazaInteres);

        decimal Saldo = vD.ImporteDepositado - (vD.TotalAporteEmpleados + vD.TotalAporteSocios);

        // Pago con interes ( por el sistema nuevo ) o sea pago de mas por lo tanto no se toma intereses
        bool PagoConInteres = Saldo > 0;

        decimal InteresGenerado =
                 CalcularInteres(Convert.ToDateTime(vD.FechaDePago), Convert.ToDateTime(vD.Periodo),
                 vD.ImporteDepositado, Capital, FechaVencimiento, TipoInteres, TazaInteres, PagoConInteres);

        if (Capital < 0)
        {
          Capital *= -1;
        }

        decimal Total = CalcularTotal(Capital, InteresGenerado);

        vD.DeudaGenerada = Capital;
        vD.InteresGenerado = InteresGenerado;
        vD.DiasDeMora = DiasDeMora;
        vD.Total = Total;
      }
      return VD_Detalle;
    }


    public static decimal CalcularCapital(decimal Depositado, decimal titem1, decimal titem2, DateTime? FechaDePago, DateTime FechaDeVencimientoDeActa, DateTime Periodo, int TipoDeInteres, decimal TazaDeInteres)
    {
      decimal Saldo = Depositado - (titem1 + titem2);//ImporteDDJJ;

      if (Saldo > 0)
      {
        Saldo = 0; // POR QUE PAGO CON SISTEMA NUEVO QUE YA INCLUYE LOS INTERESES (o sea paga de mas)
      }

      return Saldo;

    }

    public static decimal CalcularInteres(DateTime? FechaDePago, DateTime Periodo, decimal ImporteDepositado, decimal importe, DateTime FechaVencimiento, int TipoInteres, decimal Interes, bool PagoConInteres)
    {
      decimal interes;
      if (TipoInteres == 1) //TipoInteres == 1 => AFIP
      {
        interes = mtdIntereses.CalcularInteresAFIP(FechaDePago, Periodo, FechaVencimiento, importe, TipoInteres, Interes);// .GetInteresAFIP(Periodo, Convert.ToDateTime(FechaDePago), importe, TipoInteres, FechaVencimiento); 
        //interes = mtdIntereses.GetInteresAFIP(Periodo, Convert.ToDateTime(FechaDePago), importe, TipoInteres, FechaVencimiento); //CalcularInteres(FechaDePago, Periodo, importe, FechaVencimiento);
      }
      else
      {
        interes = mtdIntereses.GetInteresManual2(FechaDePago, Periodo, FechaVencimiento, ImporteDepositado, importe, Interes, PagoConInteres); //CalcularInteresManual(Periodo,FechaVencimiento,importe,Interes);
      }
      return interes;
    }

    public static int CalcularDias(DateTime Periodo, DateTime FechaVencimiento)
    {
      DateTime FechaVencimientoPeriodo = Periodo.AddMonths(1).AddDays(14);
      int dias = Convert.ToInt32((FechaVencimiento - FechaVencimientoPeriodo).TotalDays);
      return dias > 0 ? dias : 0;
    }

    public static decimal CalcularTotal(decimal ImporteNoDepositado, decimal Interes)
    {
      return ImporteNoDepositado + Interes;
    }

    public static string GetNroDeActa(DateTime Periodo, string Cuit)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        //var NroActa = context.ACTAS.Where(x => x.CUIT_STR == Cuit && (x.DESDE <= Periodo && Periodo <= x.HASTA)).FirstOrDefault();
        var NroActa = context.Acta.Where(x => x.EmpresaCuit == Cuit && (x.Desde <= Periodo && Periodo <= x.Hasta)).FirstOrDefault();
        return NroActa == null ? "" : NroActa.Numero.ToString();
      }
    }

    public static string GetNroVerifDeuda(string cuit, DateTime Periodo, int Rectificacion, bool PerNoDec, DateTime? FechaDePago)
    {
      //if (FechaDePago == null)
      //{
      //  FechaDePago = Convert.ToDateTime("0001 - 01 - 01 00:00:00.0000000");
      //}
      using (var context = new lts_sindicatoDataContext())
      {
        string vd = "";
        var InspectorVerifId = from a in context.VD_Inspector where a.CUIT == cuit && a.Estado == 0 select new { a.Id };
        if (InspectorVerifId.Count() > 0)
        {
          var VerifDeuda = context.VD_Detalle.Where(x => x.VDInspectorId == InspectorVerifId.Single().Id && x.Periodo == Periodo && x.Rectificacion == Rectificacion && x.FechaDePago == FechaDePago);
          if (VerifDeuda.Count() > 0)
          {
            if (PerNoDec)
            {
              vd = VerifDeuda.Single().Id.ToString();
            }
            else
            {
              vd = VerifDeuda.Single().VDInspectorId.ToString();
            }
          }
        }
        return vd;
      }
    }



  }
}

