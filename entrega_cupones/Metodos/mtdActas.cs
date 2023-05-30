using entrega_cupones.Formularios;
using entrega_cupones.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entrega_cupones.Metodos
{
  class mtdActas
  {
    public static mdlActa ActaReturn = new mdlActa();
    public static List<Empresa> _Empresas = mtdEmpresas.GetListadoEmpresas();
    public static List<mdlInspector> _Inspectores = mtdInspectores.Get_Inspectores();

    public static int ObtenerNroDeActa()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        return context.Acta.Count() > 0 ? context.Acta.Max(x => x.Numero) + 1 : 1;
      }
    }

    public static void GuardarActaCabecera(List<EstadoDDJJ> ddjjt, DateTime FechaDeConfeccion, DateTime desde, DateTime hasta, DateTime vencimiento, int empresaId, string cuit, int cantidadEmpleados, decimal InteresMensual, decimal InteresDiario, List<mdlCuadroAmortizacion> _PlanDePago, int InspectorId, decimal _Deuda, decimal _Interes, decimal _Total)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        int NroDeActa = ObtenerNroDeActa();

        int NroDePlan = mtdCobranzas.AsentarPlan(cuit, NroDeActa, _PlanDePago);

        MessageBox.Show("Se grabo el Plan de Pago con exito");

        Acta acta = new Acta();
        acta.Fecha = FechaDeConfeccion;
        acta.Numero = NroDeActa;
        acta.EmpresaCuit = cuit;
        acta.Desde = desde;
        acta.Hasta = hasta;
        acta.Vencimiento = vencimiento;
        acta.EmpresaId = empresaId;
        acta.Capital = _Deuda; //Math.Round(ddjjt.Sum(x => x.Capital), 2);
        acta.EmpresaCuit = cuit;
        acta.Interes = _Interes;//Math.Round(ddjjt.Sum(x => x.Interes), 2);
        acta.Total = _Total;//Math.Round(ddjjt.Sum(x => x.Total), 2);
        acta.PlanDePago = NroDePlan;
        acta.InspectorId = InspectorId;
        acta.EmpleadosCantidad = cantidadEmpleados;
        acta.InteresMensualAplicado = InteresMensual;
        acta.InteresDiarioAplicado = InteresDiario;

        context.Acta.InsertOnSubmit(acta);
        context.SubmitChanges();

        MessageBox.Show("Se grabo el Acta con exito");
        int actaId = context.Acta.Where(x => x.EmpresaCuit == acta.EmpresaCuit && x.Numero == acta.Numero).SingleOrDefault().Id;

        GuardarActaDetalle(ddjjt, acta.Numero, acta.EmpresaCuit, actaId);
        MessageBox.Show("Se grabo el detalle del Acta con exito");
      }
    }


    public static void GuardarActaDetalle(List<EstadoDDJJ> ddjjt, int actaNumero, string actaCuit, int actaId)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        foreach (var periodo in ddjjt)
        {
          ActasDetalle actadet = new ActasDetalle
          {
            NumeroDeActa = actaNumero,
            ActaId = actaId,
            Periodo = periodo.Periodo,
            CantidadEmpleados = periodo.Empleados,
            CantidadSocios = periodo.Socios,
            TotalSueldoEmpleados = periodo.TotalSueldoEmpleados,
            TotalSueldoSocios = periodo.TotalSueldoSocios,
            TotalAporteEmpleados = periodo.AporteLey,
            TotalAporteSocios = periodo.AporteSocio,
            FechaDePago = Convert.ToDateTime(periodo.FechaDePago),
            ImporteDepositado = periodo.ImporteDepositado,
            DiasDeMora = periodo.DiasDeMora,
            DeudaGenerada = periodo.Capital,
            InteresGenerado = periodo.Interes,
            Total = periodo.Total,
            PerNoDec = periodo.PerNoDec

          };
          context.ActasDetalle.InsertOnSubmit(actadet);
          context.SubmitChanges();
        }
      }
    }

    public static int GuardarActaCabecera2(List<mdlVDDetalle> VDDetalle, DateTime FechaDeConfeccion, DateTime desde, DateTime hasta, DateTime vencimiento, int empresaId, string cuit, int cantidadEmpleados, decimal InteresMensual, decimal InteresDiario, int InspectorId, decimal _Deuda, decimal _Interes, decimal _Total, int NroDePlan, int NroVD )
    {
      using (var context = new lts_sindicatoDataContext())
      {

        int NroDeActa = ObtenerNroDeActa();

        Acta acta = new Acta();
        acta.Fecha = FechaDeConfeccion;
        acta.Numero = NroDeActa;
        acta.EmpresaCuit = cuit;
        acta.Desde = desde;
        acta.Hasta = hasta;
        acta.Vencimiento = vencimiento;
        acta.EmpresaId = empresaId;
        acta.Capital = _Deuda;
        acta.Interes = _Interes;
        acta.Total = _Total;
        acta.PlanDePago = NroDePlan;
        acta.InspectorId = InspectorId;
        acta.EmpleadosCantidad = cantidadEmpleados;
        acta.InteresMensualAplicado = InteresMensual;
        acta.InteresDiarioAplicado = InteresDiario;

        context.Acta.InsertOnSubmit(acta);
        context.SubmitChanges();

        MessageBox.Show("Se grabo el Acta con exito");
        int actaId = context.Acta.Where(x => x.EmpresaCuit == acta.EmpresaCuit && x.Numero == acta.Numero).SingleOrDefault().Id;

        GuardarNroActaEnVD(NroDeActa, NroVD);

        GuardarActaDetalle2(VDDetalle, acta.Numero, acta.EmpresaCuit, actaId);
        MessageBox.Show("Se grabo el detalle del Acta con exito");
        return NroDeActa;
      }
    }

    public static void GuardarActaDetalle2(List<mdlVDDetalle> VDDetalle, int actaNumero, string actaCuit, int actaId)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        foreach (var periodo in VDDetalle)
        {
          ActasDetalle actadet = new ActasDetalle
          {
            NumeroDeActa = actaNumero,
            ActaId = actaId,
            Periodo = (DateTime)periodo.Periodo,
            CantidadEmpleados = periodo.CantidadEmpleados,
            CantidadSocios = periodo.CantidadSocios,
            TotalSueldoEmpleados = periodo.TotalSueldoEmpleados,
            TotalSueldoSocios = periodo.TotalSueldoSocios,
            TotalAporteEmpleados = periodo.TotalAporteEmpleados,
            TotalAporteSocios = periodo.TotalAporteSocios,
            FechaDePago = Convert.ToDateTime(periodo.FechaDePago),
            ImporteDepositado = periodo.ImporteDepositado,
            DiasDeMora = periodo.DiasDeMora,
            DeudaGenerada = periodo.DeudaGenerada,
            InteresGenerado = periodo.InteresGenerado,
            Total = periodo.Total,
            PerNoDec = periodo.PerNoDec
          };
          context.ActasDetalle.InsertOnSubmit(actadet);
          context.SubmitChanges();
        }

      }
    }

    public static void   GuardarNroActaEnVD(int _NroActa, int NroVD)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var ActaInVD = context.VD_Inspector.Where(x => x.Numero == NroVD).SingleOrDefault();
        ActaInVD.NroDeActa = _NroActa;
        context.SubmitChanges();
      }
    }

    public static mdlActa GetActa(int NroDeActa)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var acta = from a in context.Acta.Where(x => x.Numero == NroDeActa)
                   join b in context.maeemp on a.EmpresaCuit equals b.MEEMP_CUIT_STR
                   select new mdlActa
                   {
                     NroActa = a.Numero,
                     Fecha = a.Fecha,
                     Cuit = a.EmpresaCuit,
                     Domicilio = b.MAEEMP_CALLE.Trim() + " " + b.MAEEMP_NRO,
                     Localidad = mtdFuncUtiles.GetLocalidad(Convert.ToInt32(b.MAEEMP_CODLOC)),
                     CodigoPostal = b.MAEEMP_CODPOS,
                     RazonSocial = b.MAEEMP_RAZSOC,
                     Desde = (DateTime)a.Desde,
                     Hasta = (DateTime)a.Hasta,
                     FechaVenc = a.Vencimiento,
                     Importe = a.Total,
                     NroDePlan = a.PlanDePago,
                     CantidadEmpleados = a.EmpleadosCantidad,
                     TelefonoEmpresa = b.MAEEMP_TEL,
                     InteresMensual = a.InteresMensualAplicado,
                     InteresDiario = a.InteresDiarioAplicado,
                     Capital = a.Capital,
                     Interes = a.Interes,
                     Total = a.Total

                   };
        ActaReturn = acta.FirstOrDefault();
        return ActaReturn;
      }
    }


    public static List<mdlDeudaParaRanking> DeudaParaRanking()
    {
      DateTime FechaVacia = Convert.ToDateTime("01/01/0001");
      List<mdlDeudaParaRanking> deudaParaRanking = new List<mdlDeudaParaRanking>();

      using (var context = new lts_sindicatoDataContext())
      {
        foreach (var empresa in context.maeemp)
        {
          mdlDeudaParaRanking dpr = new mdlDeudaParaRanking();
          dpr.Cuit = empresa.MEEMP_CUIT_STR;
          dpr.Empresa = empresa.MAEEMP_RAZSOC.Trim();
          dpr.Deuda = CalcularDeudaRanking(empresa.MEEMP_CUIT_STR);
          if (dpr.Deuda > 0)
          {
            deudaParaRanking.Add(dpr);
          }
        }
      }

      return deudaParaRanking.OrderByDescending(x => x.Deuda).ToList();

    }

    public static decimal CalcularDeudaRanking(string cuit)
    {
      //List<mdlDeudaParaRanking> deudaParaRanking = new List<mdlDeudaParaRanking>();
      using (var context = new lts_sindicatoDataContext())
      {
        var deuda = context.ddjjt.Where(x => x.CUIT_STR == cuit && x.fpago == null).Sum(x => x.titem1 + x.titem2);

        return Convert.ToDecimal(deuda);
      }
    }

    public static List<mdlActa> Get_ListadoDeActas()
    {
      using (var datacontext = new lts_sindicatoDataContext())
      {
        var actas = (from a in datacontext.Acta
                       //where a.Estado == 0 || a.Estado == 1
                     select new mdlActa
                     {
                       NroActa = a.Numero,
                       Fecha = Convert.ToDateTime(a.Fecha),
                       Cuit = a.EmpresaCuit,
                       RazonSocial = GetEmpresaNombre(a.EmpresaCuit),
                       Desde = Convert.ToDateTime(a.Desde),
                       Hasta = Convert.ToDateTime(a.Hasta),
                       Importe = a.Total,
                       NroDePlan = a.PlanDePago,
                       InspectorId = a.InspectorId,
                       InspectorNombre = Get_InspectorNombre(a.InspectorId),
                       Estado = a.Estado
                     }).OrderByDescending(x => x.NroActa).ToList();

        //actas.ForEach(x => x.RazonSocial = empresas.Where(y=>y.MEEMP_CUIT_STR == x.Cuit).FirstOrDefault().MAEEMP_RAZSOC);//mtdEmpresas.GetEmpresaNombre(x.Cuit));
        //actas.ForEach(x => x.InspectorNombre = mtdInspectores.Get_InspectorNombre(x.InspectorId));

        return actas;
      }
    }

    public static string GetEmpresaNombre(string cuit)
    {
      string nombre = string.Empty;
      using (var context = new lts_sindicatoDataContext())
      {
        if (!string.IsNullOrWhiteSpace(cuit))
        {
          var n = from a in _Empresas where a.MEEMP_CUIT_STR == cuit select new { Nombre = a.MAEEMP_RAZSOC.Trim() };// + " - " + a.MAEEMP_NOMFAN.Trim() };

          nombre = n.Count() > 0 ? n.SingleOrDefault().Nombre : "";

        }
      }
      return nombre;
    }

    public static string Get_InspectorNombre(int InspectorId)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var inspector = from a in _Inspectores
                        where a.Id == InspectorId
                        select new { Nombre = a.Nombre };


        if (inspector.Count() > 0)
        {
          return inspector.Single().Nombre;
        }
        else
        {
          return "";
        }

      }
    }

    public static void ReimprimirActa(int NumeroActa)
    {
      mdlActa Acta = GetActa(NumeroActa);

      frm_GenerarActa formActasGenerar = new frm_GenerarActa();

      formActasGenerar.NombreInspector = GetNombreInspector(NumeroActa);
      formActasGenerar.msk_FechaConfeccion.Text = Convert.ToDateTime(Acta.Fecha).ToString("dd/MM/yyyy");
      formActasGenerar.txt_NumeroDeActa.Text = Acta.NroActa.ToString();
      formActasGenerar.txt_CantidadEmpleado.Text = Acta.CantidadEmpleados.ToString();
      formActasGenerar.txt_CodigoPostal.Text = Acta.CodigoPostal;
      formActasGenerar.EsReimpresion = true;
      formActasGenerar.txt_CUIT.Text = Acta.Cuit; //txt_CUIT.Text;
      formActasGenerar.txt_RazonSocial.Text = Acta.RazonSocial;// txt_BuscarEmpesa.Text;
      formActasGenerar.txt_Domicilio.Text = Acta.Domicilio;
      formActasGenerar.txt_Localidad.Text = Acta.Localidad;
      formActasGenerar.msk_Desde.Text = Convert.ToDateTime(Acta.Desde).ToString("MM/yyyy"); //msk_Desde.Text;
      formActasGenerar.msk_Hasta.Text = Convert.ToDateTime(Acta.Hasta).ToString("MM/yyyy");// msk_Hasta.Text;
      formActasGenerar.msk_Vencimiento.Text = Convert.ToDateTime(Acta.FechaVenc).ToString("dd/MM/yyyy");//msk_Vencimiento.Text;
      formActasGenerar.msk_LibroSueldoDesde.Text = Convert.ToDateTime(Acta.Desde).ToString("MM/yyyy");//msk_Desde.Text;
      formActasGenerar.msk_LibroSueldoHasta.Text = Convert.ToDateTime(Acta.Hasta).ToString("MM/yyyy");//msk_Hasta.Text;
      formActasGenerar.msk_ReciboSueldoDesde.Text = Convert.ToDateTime(Acta.Desde).ToString("dd/MM/yyyy"); //msk_Desde.Text;
      formActasGenerar.msk_ReciboSueldoHasta.Text = Convert.ToDateTime(Acta.Hasta).ToString("MM/yyyy"); //msk_Hasta.Text;
      formActasGenerar.msk_BoletaDepositoDesde.Text = Convert.ToDateTime(Acta.Desde).ToString("MM/yyyy"); //msk_Desde.Text;
      formActasGenerar.msk_BoletaDepositoHasta.Text = Convert.ToDateTime(Acta.Hasta).ToString("MM/yyyy");// msk_Hasta.Text;
      formActasGenerar.txt_Total.Text = Acta.Importe.ToString("N2"); //txt_Total.Text;
      formActasGenerar.txt_Interes.Text = Acta.InteresMensual.ToString(); //txt_Interes.Text;
      formActasGenerar.txt_InteresDiario.Text = Acta.InteresDiario.ToString();//txt_InteresDiario.Text;
      formActasGenerar.txt_Cuotas.Text = "";//txt_CantidadDeCuotas.Text;
      formActasGenerar.txt_ImporteDeCuota.Text = "";// txt_ImporteDeCuota.Text;
      formActasGenerar.txt_Telefono.Text = Acta.TelefonoEmpresa;
      //formActasGenerar.cbx_Inspectores.Text = 
      formActasGenerar.Show();


    }

    public static void GetDDJJPorNumeroActa(int NumeroActa)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        List<EstadoDDJJ> estadoDDJJs = new List<EstadoDDJJ>();
        //string fechaVacia = "01/01/0001";
        var _ddjj = from a in context.ActasDetalle
                    where a.NumeroDeActa == NumeroActa
                    select new EstadoDDJJ
                    {
                      Periodo = Convert.ToDateTime(a.Periodo),
                      AporteLey = (decimal)a.TotalAporteEmpleados,
                      AporteSocio = (decimal)a.TotalAporteSocios,
                      TotalSueldoEmpleados = (decimal)a.TotalSueldoEmpleados,// * Convert.ToDecimal(0.02),
                      TotalSueldoSocios = (decimal)a.TotalSueldoSocios,// * Convert.ToDecimal(0.02),
                      FechaDePago = a.FechaDePago, //a.FechaDePago == null ? null : Convert.ToDateTime(a.FechaDePago),// a.FechaDePago == null ? null : a.FechaDePago,
                      ImporteDepositado = (decimal)a.ImporteDepositado,
                      Empleados = a.CantidadEmpleados,
                      Socios = a.CantidadSocios,
                      Capital = a.DeudaGenerada,
                      Interes = a.InteresGenerado,
                      DiasDeMora = a.DiasDeMora,
                      Total = a.Total
                    };
        estadoDDJJs.AddRange(_ddjj);
        //estadoDDJJs.ForEach(x => x.FechaDePago.ToString() == fechaVacia ? null : x.FechaDePago);
        mdlActa Acta = GetActa(NumeroActa);
        ReimprimirDDJJ(estadoDDJJs, Acta);
      }
    }

    public static void ReimprimirDDJJ(List<EstadoDDJJ> ddjj, mdlActa acta)
    {
      DS_cupones ds = new DS_cupones();
      DataTable dt_ActasDetalle = ds.ActasDetalle;
      dt_ActasDetalle.Clear();

      int color = 0;
      string fecha2 = "";
      foreach (var periodo in ddjj)
      {
        DataRow row = dt_ActasDetalle.NewRow();
        row["NumeroDeActa"] = acta.NroActa;
        row["Periodo"] = periodo.Periodo;
        row["CantidadDeEmpleados"] = periodo.Empleados;
        row["CantidadSocios"] = periodo.Socios;
        row["TotalSueldoEmpleados"] = periodo.TotalSueldoEmpleados;
        row["TotalSueldoSocios"] = periodo.TotalSueldoSocios;
        row["TotalAporteEmpleados"] = periodo.AporteLey;
        row["TotalAporteSocios"] = periodo.AporteSocio;
        fecha2 = fecha2 = Convert.ToDateTime(periodo.FechaDePago).Date.ToString("dd/MM/yyyy");// periodo.FechaDePago.ToString("dd/MM/yyyy");
        if (fecha2 != "")
        {
          if (fecha2 != "01/01/0001")
          {
            fecha2 = Convert.ToDateTime(periodo.FechaDePago).Date.ToString("dd/MM/yyyy");
          }
          else
          {
            fecha2 = "";
          }
        }
        else
        {
          fecha2 = "";
        }
        row["FechaDePago"] = fecha2;//periodo.FechaDePago.ToString();//== null ? "01/01/0001" : periodo.FechaDePago.Value.Date.ToString();
        row["ImporteDepositado"] = periodo.ImporteDepositado;
        row["DiasDeMora"] = periodo.DiasDeMora;
        row["DeudaGenerada"] = periodo.Capital;
        row["InteresGenerado"] = periodo.Interes;
        row["Total"] = periodo.Total;
        row["Color"] = color;
        color = color == 1 ? 0 : 1;
        dt_ActasDetalle.Rows.Add(row);
      }

      Empresa empresa = mtdEmpresas.GetEmpresa(acta.Cuit);

      reportes formReporte = new reportes();
      formReporte.dt = dt_ActasDetalle;
      formReporte.dt2 = mtdFilial.Get_DatosFilial();

      formReporte.Parametro1 = empresa.MAEEMP_RAZSOC.Trim();
      formReporte.Parametro2 = empresa.MEEMP_CUIT_STR;
      formReporte.Parametro3 = mtdFuncUtiles.generar_ceros(acta.NroActa.ToString(), 6);
      formReporte.Parametro4 = acta.Capital.ToString("N2"); // _PreActa.Sum(x => x.Capital).ToString("N2");
      formReporte.Parametro5 = acta.Interes.ToString(); // _PreActa.Sum(x => x.Interes).ToString("N2");
      formReporte.Parametro6 = acta.Total.ToString();// _PreActa.Sum(x => x.Total).ToString("N2");
      formReporte.Parametro7 = "Original";
      formReporte.Parametro8 = " ";
      formReporte.Parametro9 = Convert.ToDateTime(acta.FechaVenc).ToString("dd/MM/yyyy");//msk_Vencimiento.Text;
      formReporte.Parametro10 = acta.Domicilio;// txt_Domicilio.Text + " " + txt_Localidad.Text;
      formReporte.NombreDelReporte = "entrega_cupones.Reportes.rpt_ActaDetalle.rdlc";
      formReporte.Show();
    }

    public static string GetNombreInspector(int NumeroActa)
    {

      using (var context = new lts_sindicatoDataContext())
      {

        Int32 IdInspector = (from a in context.Acta
                             where a.Numero == NumeroActa
                             select a).SingleOrDefault().InspectorId;
        return mtdInspectores.Get_Inspector(IdInspector).Nombre;
      }
    }

    public static bool AnularActa(int NroActa)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var anular = from a in context.Acta where a.Numero == NroActa select a;
        if (anular.Count() > 0)
        {
          anular.Single().Estado = 1;
          context.SubmitChanges();
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    public static bool VerificarSiEstaAnulada(int NroActa)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        return (from a in context.Acta where a.Numero == NroActa && a.Estado == 1 select a).Count() > 0;
      }
    }

  }
}
