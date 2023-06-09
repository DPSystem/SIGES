﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Clases
{
  public class calcular_coeficientes
  {
    public class clsPeriodos
    {
      public int Id { get; set; }
      public DateTime Desde { get; set; }
      public DateTime Hasta { get; set; }
      public string Norma { get; set; }
      public int TipoDeInteres { get; set; }
      public decimal Diario { get; set; }
      public decimal Mensual { get; set; }
    }
    public double calcular_coeficiente_A(DateTime periodo, DateTime fpago, double tot_periodo, double pagado, DateTime fecha_venc_acta)
    {
      if (tot_periodo == 0 && pagado != 0)
      {
        tot_periodo = pagado;
      }

      double tot_interes_mora_de_pago = 0;
      double tot_intereses_a_la_fecha = 0;
      double coef_A = 0;
      double coef_B = 0;
      DateTime fecha_vencimiento = periodo.AddMonths(1);
      fecha_vencimiento = fecha_vencimiento.AddDays(14);

      if (fpago > fecha_vencimiento)
      {
        coef_A = Math.Round(((fpago - fecha_vencimiento).TotalDays * 0.001), 5);
        tot_interes_mora_de_pago = tot_periodo - pagado + (pagado * coef_A);
        coef_B = ((fecha_venc_acta - fecha_vencimiento).TotalDays * 0.001) + 1;
        tot_intereses_a_la_fecha = ((tot_periodo - pagado) * coef_B) + ((pagado * coef_A) * (coef_B - coef_A));
      }
      return tot_intereses_a_la_fecha; //tot_interes_mora_de_pago;
    }
    public double calcular_coeficiente_B(DateTime periodo, double tot_periodo, double pagado, DateTime fecha_venc_acta)
    {
      if (tot_periodo == 0 && pagado != 0)
      {
        tot_periodo = pagado;
      }
      double tot_intereses_a_la_fecha = 0;
      double coef_A = 0;
      double coef_B = 0;
      DateTime fecha_vencimiento = periodo.AddMonths(1);
      fecha_vencimiento = fecha_vencimiento.AddDays(14);
      coef_B = ((fecha_venc_acta - fecha_vencimiento).TotalDays * 0.001) + 1;
      tot_intereses_a_la_fecha = ((tot_periodo - pagado) * coef_B) + ((pagado * coef_A) * (coef_B - coef_A));

      return tot_intereses_a_la_fecha; //tot_interes_mora_de_pago;
    }
    public decimal CalcularInteresResarcitorio(DateTime FechaDeVencimiento, DateTime FechaDePago, double ImporteAbonado, double ImporteDeuda, int TipoInteres, int CuotaId)
    {

      FechaDeVencimiento = FechaDeVencimiento.AddDays(1);
      decimal interes = 0;
      int dias = 0;
      clsPeriodos UltPer = new clsPeriodos();

      using (var context = new lts_sindicatoDataContext()) 
      {
        var Inicio = context.Intereses.Where(x => x.TipoDeInteres == TipoInteres && FechaDeVencimiento >= x.Desde && FechaDeVencimiento <= x.Hasta).Single();

        var Final = context.Intereses.Where(x => x.TipoDeInteres == TipoInteres && FechaDePago >= x.Desde && FechaDePago <= x.Hasta).Single();

        var Periodos = context.Intereses.Where(x => x.TipoDeInteres == TipoInteres && x.Id >= Inicio.Id && x.Id <= Final.Id).OrderBy(x => x.Desde);

        int cuotaID = CuotaId;

        foreach (var item in Periodos)
        {
          if (FechaDeVencimiento < FechaDePago) //Para no calcular interes
          {

            if (Inicio.Id == Final.Id) //para saber si estamos en un solo intervalo
            {
              dias = Convert.ToInt32((FechaDePago - FechaDeVencimiento).TotalDays);
            }
            else
            {
              if (Inicio.Id == item.Id) // este es el primer registro
              {
                dias = Convert.ToInt32((Convert.ToDateTime(item.Hasta) - FechaDeVencimiento).TotalDays);
              }

              if (Final.Id == item.Id) // Este Es el ultimo registro
              {
                dias = Convert.ToInt32((FechaDePago - Convert.ToDateTime(item.Desde)).TotalDays);
              }

              if (item.Id > Inicio.Id && item.Id < Final.Id)
              {
                dias = Convert.ToInt32((Convert.ToDateTime(item.Hasta) - Convert.ToDateTime(item.Desde)).TotalDays);
              }
            }

            interes += (Math.Round(Convert.ToDecimal(ImporteDeuda), 4) * Convert.ToDecimal(dias * item.Diario)) / 100;
          }
          else
          {
            interes = 0;
          }
        }
      }
      return interes;
    }
    public Double ObtenerTotalDeCuotaDePlanDePago(DateTime FechaDeVencimiento, DateTime FechaDePago, double ImporteAbonado, double ImporteDeuda, int TipoInteres, int CuotaId)
    {
      return ImporteDeuda + Convert.ToDouble(CalcularInteresResarcitorio(FechaDeVencimiento, FechaDePago, ImporteAbonado, ImporteDeuda, TipoInteres, CuotaId));
    }
  }
}

