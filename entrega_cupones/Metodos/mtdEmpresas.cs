using entrega_cupones.Modelos;
using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace entrega_cupones.Metodos
{
  class mtdEmpresas
  {
    public static Empresa empresa = new Empresa();

    public static List<EstadoDDJJ> _ddjj = new List<EstadoDDJJ>();

    public static List<EstadoDDJJ> ListadoDDJJT(string cuit, DateTime desde, DateTime hasta, DateTime FechaVencimientoActa, int TipoInteres, decimal TazaInteres)
    {
      _ddjj.Clear();
      using (var context = new lts_sindicatoDataContext())
      {
        var _EstadoDDJJ = context.ddjjt.Where(x => x.CUIT_STR == cuit && (x.periodo >= desde && x.periodo <= hasta))
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
           Empleados = context.ddjj.Where(x => x.CUIT_STR == cuit && (x.periodo == row.periodo) && (x.rect == row.rect)).Count(),
           Socios = context.ddjj.Where(x => x.CUIT_STR == cuit && (x.periodo == row.periodo) && x.rect == row.rect && x.item2 == true).Count(),

           Acta = GetNroDeActa(Convert.ToDateTime(row.periodo), row.CUIT_STR),
           VerifDeuda = GetNroVerifDeuda(cuit, Convert.ToDateTime(row.periodo), Convert.ToInt32(row.rect), false, Convert.ToDateTime(row.fpago))
         });

        _ddjj.AddRange(_EstadoDDJJ);

        foreach (var vD in _ddjj)
        {
          int DiasDeMora = CalcularDias(Convert.ToDateTime(vD.Periodo), vD.FechaDePago == null ? FechaVencimientoActa : Convert.ToDateTime(vD.FechaDePago));

          decimal Capital = CalcularCapital(vD.ImporteDepositado, (vD.AporteLey + vD.AporteSocio),
                Convert.ToDateTime(vD.FechaDePago), FechaVencimientoActa, Convert.ToDateTime(vD.Periodo),
                TipoInteres, TazaInteres, DiasDeMora);

          decimal Saldo = vD.ImporteDepositado - (vD.AporteLey + vD.AporteSocio);

          // Pago con interes ( por el sistema nuevo ) o sea pago de mas por lo tanto no se toma intereses
          bool PagoConInteres = Saldo > 0;

          decimal InteresGenerado =
                CalcularInteres(Convert.ToDateTime(vD.FechaDePago), Convert.ToDateTime(vD.Periodo),
                 vD.ImporteDepositado, Capital, FechaVencimientoActa, TipoInteres, TazaInteres, PagoConInteres);

          if (Capital < 0)
          {
            Capital *= -1;
          }

          decimal Total = CalcularTotal(Capital, InteresGenerado);

          vD.Capital = Capital;
          vD.Interes = InteresGenerado;
          vD.DiasDeMora = DiasDeMora;
          vD.Total = Total;

        }

        EliminarRectificacion();
        return _ddjj.Union(GenerarPerNoDec(desde, hasta, cuit)).OrderBy(x => x.Periodo).ToList();
      }
    }

    public static decimal CalcularCapital(decimal Depositado, decimal ImporteDDJJ, DateTime? FechaDePago, DateTime FechaDeVencimientoDeActa, DateTime Periodo, int TipoDeInteres, decimal TazaDeInteres, int DiasDeMora)
    {
      decimal Saldo = Depositado - ImporteDDJJ;

      if (Saldo > 0)
      {
        Saldo = 0; // POR QUE PAGO CON SISTEMA NUEVO QUE YA INCLUYE LOS INTERESES (o sea paga de mas)
      }

      return Saldo;
    }

    public static decimal DifAporteSocioJorPar(string Cuit, DateTime Periodo, int Rectif)
    {
      List<mdlDDJJEmpleado> lists = mtdEmpleados.ListadoEmpleadoAporte(Cuit, Periodo, Rectif);
      decimal DiferenciaAporteSocioJorPar = lists.Where(x => x.Jornada == "Parcial").Sum(x => x.AporteSocioDif);
      return DiferenciaAporteSocioJorPar;
    }

    public static decimal CalcularInteres(DateTime? FechaDePago, DateTime Periodo, decimal ImporteDepositado, decimal importe, DateTime FechaVencimientoDeActa, int TipoInteres, decimal Interes, bool PagoConInteres)
    {
      decimal interes;

      if (TipoInteres == 1) //TipoInteres == 1 => AFIP
      {
        interes = mtdIntereses.CalcularInteresAFIP(FechaDePago, Periodo, FechaVencimientoDeActa, importe, TipoInteres, Interes);// .GetInteresAFIP(Periodo, Convert.ToDateTime(FechaDePago), importe, TipoInteres, FechaVencimiento); 
        //interes = mtdIntereses.GetInteresAFIP(Periodo, Convert.ToDateTime(FechaDePago), importe, TipoInteres, FechaVencimiento); //CalcularInteres(FechaDePago, Periodo, importe, FechaVencimiento);
      }
      else
      {
        interes = mtdIntereses.GetInteresManual2(FechaDePago, Periodo, FechaVencimientoDeActa, ImporteDepositado, importe, Interes, PagoConInteres); //CalcularInteresManual(Periodo,FechaVencimiento,importe,Interes);
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

    public static void EliminarRectificacion()
    {
      var agrupado = _ddjj.GroupBy(x => x.Periodo).Where(x => x.Count() > 1);
      foreach (var item in agrupado)
      {
        // en la variable sss almaceno la suma del grupo y si es igual a cero quiere decir que hay rectificaciones pero niguna pagada 
        // por lo tanto en la variable MayorRectif alamceno la rectificacion mas alta la cual no debo eliminar
        // entonces comparo ambas y si son distintas la elimino y si son iguales no las elimino

        decimal sss = item.Sum(x => x.ImporteDepositado);
        string MayorRectif = "0";
        if (sss == 0)
        {
          MayorRectif = item.Max(x => x.Rectificacion).ToString();
        }
        foreach (var registro in item)
        {
          if (registro.ImporteDepositado == 0 && Convert.ToString(registro.Rectificacion) != MayorRectif)
          {
            _ddjj.RemoveAll(x => x.Periodo == registro.Periodo && x.Rectificacion == registro.Rectificacion);
          }
          else
          {
            if (sss > 0)
            {
              if (registro.ImporteDepositado == 0)
              {
                _ddjj.RemoveAll(x => x.Periodo == registro.Periodo && x.Rectificacion == registro.Rectificacion);
              }
            }
          }
        }
      }
    }

    public static List<EstadoDDJJ> GenerarPerNoDec(DateTime Desde, DateTime Hasta, string cuit)
    {
      List<EstadoDDJJ> Periodos = new List<EstadoDDJJ>();
      DateTime periodo = Desde; // Convert.ToDateTime("01/" + msk_Desde.Text);
      DateTime hasta = Hasta; // Convert.ToDateTime("01/" + msk_Hasta.Text);

      while (periodo <= hasta)
      {
        if (_ddjj.Where(x => x.Periodo == periodo).Count() == 0)
        {
          EstadoDDJJ PerNoDec = new EstadoDDJJ();
          PerNoDec.Periodo = periodo;
          PerNoDec.Rectificacion = 0;
          PerNoDec.AporteLey = 0;
          PerNoDec.AporteSocio = 0;
          PerNoDec.FechaDePago = null;
          PerNoDec.ImporteDepositado = 0;
          PerNoDec.Empleados = 0;
          PerNoDec.Socios = 0;
          PerNoDec.Capital = 0;
          PerNoDec.Interes = 0;
          PerNoDec.Total = 0;
          PerNoDec.Acta = GetNroDeActa(periodo, cuit);
          PerNoDec.VerifDeuda = GetNroVerifDeuda(cuit, periodo, 0, false, null);
          PerNoDec.PerNoDec = 1;
          Periodos.Add(PerNoDec);
        }
        periodo = periodo.AddMonths(1);
      }
      return Periodos;
    }

    public DataTable ImprimirDeuda(DataTable dt, List<EstadoDDJJ> deuda)
    {
      dt.Clear();

      foreach (var periodo in deuda)
      {
        DataRow row = dt.NewRow();
        row["NumeroDeActa"] = 0;
        row["Periodo"] = periodo.Periodo;
        row["CantidadDeEmpleados"] = periodo.Empleados;
        row["CantidadSocios"] = periodo.Socios;
        row["TotalSueldoEmpleados"] = periodo.TotalSueldoEmpleados;
        row["TotalSueldoSocios"] = periodo.TotalSueldoSocios;
        row["TotalAporteEmpleados"] = periodo.AporteLey;
        row["TotalAporteSocios"] = periodo.AporteSocio;
        row["FechaDePago"] = periodo.FechaDePago;
        row["ImporteDepositado"] = periodo.ImporteDepositado;
        row["DiasDeMora"] = periodo.DiasDeMora;
        row["DeudaGenerada"] = periodo.Capital;
        row["InteresGenerado"] = periodo.Interes;
        row["Total"] = periodo.Total;
        dt.Rows.Add(row);
      }
      return dt;
    }

    public static Empresa GetEmpresa(string Cuit)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var emp = context.maeemp.Where(x => x.MEEMP_CUIT_STR == Cuit).Select(
          x => new Empresa
          {
            MAEEMP_CUIT = (float)x.MAEEMP_CUIT,
            MAEEMP_NOMFAN = x.MAEEMP_NOMFAN.Trim(),
            MAEEMP_RAZSOC = x.MAEEMP_RAZSOC.Trim(),
            MAEEMP_CALLE = x.MAEEMP_CALLE.Trim(),
            MAEEMP_NRO = x.MAEEMP_NRO.Trim(),
            MAEEMP_CODPROV = x.MAEEMP_CODPROV.ToString(),
            MAEEMP_CODLOC = x.MAEEMP_CODLOC.ToString(),
            MAEEMP_CODPOS = x.MAEEMP_CODPOS.ToString(),
            MAEEMP_EMAIL = x.MAEEMP_EMAIL.ToString(),
            //MAEEMP_CREDMAX =  x.MAEEMP_CREDMAX,
            MAEEMP_CONDCRED = x.MAEEMP_CONDCRED.ToString(),
            //MAEEMP_CONDIVA =  ,
            //MAEEMP_ACTUALIZA = (bool) x.MAEEMP_ACTUALIZA ,
            MAEEMP_ESTUDIO_CONTACTO = x.MAEEMP_ESTUDIO_CONTACTO.ToString(),
            MAEEMP_ESTUDIO_TEL = x.MAEEMP_ESTUDIO_TEL.ToString(),
            MAEEMP_ESTUDIO_EMAIL = x.MAEEMP_ESTUDIO_EMAIL.ToString(),
            MEEMP_CUIT_STR = x.MEEMP_CUIT_STR
          }).FirstOrDefault();
        empresa = emp;
        return empresa;
      }
    }

    public static string GetNroDeActa(DateTime Periodo, string Cuit)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        //var NroActa = context.ACTAS.Where(x => x.CUIT_STR == Cuit && (x.DESDE <= Periodo && Periodo <= x.HASTA)).FirstOrDefault();
        var NroActa = context.Acta.Where(x => x.EmpresaCuit == Cuit && x.Estado == 0 && (x.Desde <= Periodo && Periodo <= x.Hasta)).FirstOrDefault();
        return NroActa == null ? "" : NroActa.Numero.ToString();
      }
    }

    public static string GetNroVerifDeuda(string cuit, DateTime Periodo, int Rectificacion, bool PerNoDec, DateTime? FechaDePago)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        string vd = "";
        var InspectorVerifId = from a in context.VD_Inspector where a.CUIT == cuit && a.Estado == 0 select new { a.Id };
        if (InspectorVerifId.Count() > 0)
        {
          var VerifDeuda = context.VD_Detalle.Where(x => x.VDInspectorId == InspectorVerifId.Single().Id && x.Periodo == Periodo && x.Rectificacion == Rectificacion);//&& x.FechaDePago == FechaDePago);
          if (VerifDeuda.Count() > 0)
          {
            if (PerNoDec)
            {
              // vd = VerifDeuda.Single().Id.ToString();
              vd = VerifDeuda.FirstOrDefault().Id.ToString();
            }
            else
            {
              vd = VerifDeuda.FirstOrDefault().VDInspectorId.ToString();
            }
          }
        }
        return vd;
      }
    }

    public static string GetDomicilio(string cuit)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var emp = (from a in context.maeemp where a.MEEMP_CUIT_STR == cuit select a).SingleOrDefault(); // context.maeemp.Where(x => x.MEEMP_CUIT_STR == cuit)

        string calle = string.IsNullOrEmpty(emp.MAEEMP_CALLE) ? "" : emp.MAEEMP_CALLE.Trim();
        string numero = string.IsNullOrEmpty(emp.MAEEMP_NRO) ? "S/N" : emp.MAEEMP_NRO.Trim();
        string codigoPostal = string.IsNullOrEmpty(emp.MAEEMP_CODPOS) ? "0" : emp.MAEEMP_CODPOS.Trim();
        string domicilio = calle + " Nº " + numero + " " + codigoPostal;
        return domicilio;
      }
    }

    public static string GetEmpresaNombre(string cuit)
    {
      string nombre = string.Empty;
      using (var context = new lts_sindicatoDataContext())
      {
        if (!string.IsNullOrWhiteSpace(cuit))
        {
          var n = from a in context.maeemp where a.MEEMP_CUIT_STR == cuit select new { Nombre = a.MAEEMP_RAZSOC.Trim() + " - " + a.MAEEMP_NOMFAN.Trim() };

          nombre = n.Count() > 0 ? n.SingleOrDefault().Nombre.Trim() : "";

        }
      }
      return nombre;
    }

    public static List<Empresa> GetListadoEmpresas()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        //var n = from a in context.maeemp where a.MEEMP_CUIT_STR == cuit select new { Nombre = a.MAEEMP_RAZSOC.Trim() + " - " + a.MAEEMP_NOMFAN.Trim() };

        var empresa = from a in context.maeemp
                      select new Empresa
                      {
                        MEEMP_CUIT_STR = a.MEEMP_CUIT_STR, 
                        MAEEMP_RAZSOC = a.MAEEMP_RAZSOC// + " - " + a.MAEEMP_NOMFAN.Trim() + " - " + a.MEEMP_CUIT_STR.Trim()
                      };
        return empresa.OrderBy(x => x.MAEEMP_RAZSOC).ToList();

      }
    }

    public static DataTable GetDatosEmpresa(string CUIT)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var empresa = (from a in context.maeemp where a.MEEMP_CUIT_STR == CUIT select a).SingleOrDefault();
        DS_cupones DS = new DS_cupones();
        DataTable Dt = DS.Empresa;
        DataRow Row = Dt.NewRow();
        Row["RazonSocial"] = empresa.MAEEMP_RAZSOC;
        Row["NombreFantasia"] = empresa.MAEEMP_NOMFAN;
        Row["CUIT"] = empresa.MEEMP_CUIT_STR;
        Row["Domicilio"] = empresa.MAEEMP_CALLE + " N° " + empresa.MAEEMP_NRO;
        Row["Telefono"] = empresa.MAEEMP_TEL;
        Row["EstudioContable"] = empresa.MAEEMP_ESTUDIO_CONTACTO;
        Row["EstudioContableTelefono"] = empresa.MAEEMP_ESTUDIO_TEL;
        Dt.Rows.Add(Row);
        return Dt;
      }

    }
  }
}
