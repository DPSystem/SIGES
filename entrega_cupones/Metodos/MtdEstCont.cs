using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entrega_cupones.Modelos;
using entrega_cupones.Metodos;

namespace entrega_cupones.Metodos
{
  class MtdEstCont
  {

    //public DateTime desde;
    //public DateTime hasta;
    //public DateTime vencimiento;


    public static List<MdlEstCont> GetEstCont()
    {
      using (lts_sindicatoDataContext context = new lts_sindicatoDataContext())
      {
        var EstCont = (from a in context.EstudiosContables
                       select new MdlEstCont
                       {
                         Id = a.Id,
                         Nombre = a.Estudio ,
                         Domicilio = a.Domicilio + " - " + a.Localidad,
                         Telefono = a.Telefono,
                         Email = a.Email
                       }).OrderBy(x => x.Nombre);

        return EstCont.ToList();
      }

    }



    public static string GetEstudioNombre(int EstContId)
    {
      using (lts_sindicatoDataContext context = new lts_sindicatoDataContext())
      {

        var nombre = (from a in context.EstudiosContables
                      where a.Id == EstContId
                      select a).SingleOrDefault().Estudio;

        return nombre;
      }

    }

    public static string GetEstudioDomicilio(int EstContId)
    {
      using (lts_sindicatoDataContext context = new lts_sindicatoDataContext())
      {

        var nombre = (from a in context.EstudiosContables
                      where a.Id == EstContId
                      select a).SingleOrDefault().Domicilio;

        return nombre;
      }

    }

    public static string GetEstudioEmail(int EstContId)
    {
      using (lts_sindicatoDataContext context = new lts_sindicatoDataContext())
      {

        var nombre = (from a in context.EstudiosContables
                      where a.Id == EstContId
                      select a).SingleOrDefault().Email;

        return nombre;
      }

    }

    public static string GetEstudioTelefono(int EstContId)
    {
      using (lts_sindicatoDataContext context = new lts_sindicatoDataContext())
      {

        var nombre = (from a in context.EstudiosContables
                      where a.Id == EstContId
                      select a).SingleOrDefault().Telefono;

        return nombre;
      }

    }

    public static List<MdlDeudaEmpresa> Get_EmpresaDeuda(int EstContId, DateTime desde, DateTime hasta, DateTime fvenc)
    {
      using (lts_sindicatoDataContext context = new lts_sindicatoDataContext())
      {
        //MdlEstCont estcontdatos = GetEstContDatos(Convert.ToInt32(EstContId));

        var Empresas = (from a in context.EstudioContableEmpresa
                        join emp in context.maeemp on a.CUIT equals emp.MEEMP_CUIT_STR
                        where a.EstudioContableId == EstContId
                        select new MdlDeudaEmpresa
                        {
                          CUIT = a.CUIT,
                          Empresa = emp.MAEEMP_RAZSOC.Trim(),
                          EstContId = Convert.ToInt32(a.EstudioContableId),
                          EstudioNombre = GetEstudioNombre(Convert.ToInt32(a.EstudioContableId)),
                          EstudioDomicilio = GetEstudioDomicilio(Convert.ToInt32(a.EstudioContableId)),
                          EstudioEmail = GetEstudioEmail(Convert.ToInt32(a.EstudioContableId)),
                          EstudioTelefono = GetEstudioTelefono(Convert.ToInt32(a.EstudioContableId))
                        }).ToList();

        //Empresas.ForEach(x => x.Deuda = mtdEmpresas.ListadoDDJJT(x.CUIT, Convert.ToDateTime("01/11/2016"), Convert.ToDateTime("01/11/2021"), Convert.ToDateTime("20/11/2021"), 1, Convert.ToDecimal("0.1")).Where(y => y.Acta == "" && y.FechaDePago == null).Sum(X => X.Total));
        Empresas.ForEach(x => x.Deuda = mtdEmpresas.ListadoDDJJT(x.CUIT, desde, hasta, fvenc, 1, Convert.ToDecimal("0.1")).Where(y => y.Acta == "" && y.FechaDePago == null).Sum(X => X.Total));

        return Empresas.OrderByDescending(x => x.Deuda).ToList();
      }
    }

    public static List<MdlEstContDeudas> Get_Informe_EstContDeudas(DateTime desde, DateTime hasta, DateTime fvenc)
    {
      List<MdlEstContDeudas> EstContDeuda = new List<MdlEstContDeudas>();
      List<MdlEstCont> EstudiosContables = GetEstCont();
      foreach (var item in EstudiosContables)
      {
        MdlEstContDeudas ecd = new MdlEstContDeudas();
        ecd.EstContNombre = item.Nombre;
        ecd.Domicilio = item.Domicilio ;
        ecd.Email = item.Email;
        ecd.Telefono = item.Telefono;
        ecd.EmpresasConDeuda = Get_EmpresaDeuda(item.Id, desde, hasta, fvenc);
        EstContDeuda.Add(ecd);
      }
      return EstContDeuda;
    }
  }
}

