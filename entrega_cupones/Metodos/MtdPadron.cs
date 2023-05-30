using entrega_cupones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Metodos
{

  internal class MtdPadron
  {
    public static List<mdlDDJJEmpleado> _DDJJ = GetDDJJ();
    public static List<mdlSocio> _Padron = new List<mdlSocio>();
    public static List<MdlSECPJ> _PadronSECPJ = new List<MdlSECPJ>();

    public static List<mdlSocio> GetPadron()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var Padron = from soc in context.soccen.Where(x => x.SOCCEN_ESTADO == 1)
                     join maesoc in context.maesoc on soc.SOCCEN_CUIL equals maesoc.MAESOC_CUIL
                     join socemp in context.socemp.Where(x => x.SOCEMP_ULT_EMPRESA == 'S') on soc.SOCCEN_CUIL equals socemp.SOCEMP_CUIL
                     join empresa in context.maeemp on socemp.SOCEMP_CUITE equals empresa.MAEEMP_CUIT
                     select new mdlSocio
                     {
                       NroDeSocio = maesoc.MAESOC_NROAFIL.Trim(),
                       ApeNom = maesoc.APENOM,
                       NroDNI = maesoc.MAESOC_NRODOC,
                       RazonSocial = empresa.MAEEMP_RAZSOC,
                       CUIT = empresa.MEEMP_CUIT_STR,
                       CUIL = maesoc.MAESOC_CUIL_STR,
                       //LastDDJJ = GetDDJJByEmpleado(maesoc.MAESOC_CUIL_STR),
                       GrupoSanguineo = maesoc.MAESOC_GRUPOSANG == 1,
                       Sexo = maesoc.MAESOC_SEXO.ToString()
                     };

        _Padron.AddRange(Padron);
        _Padron.ForEach(x => x.LastDDJJ = GetDDJJByEmpleado(x.CUIL));

        return _Padron;
        ;
      }
    }

    public static List<MdlSECPJ> GetPadronSECPJ()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var PadronSECPJ = from ppj in context.PadronPJ
                          join psec in context.maesoc on ppj.Matricula equals psec.MAESOC_NRODOC
                          select new MdlSECPJ
                          {
                            CodSeccion = ppj.CodSeccion,
                            Seccion = ppj.Seccion,
                            CodCircuito = ppj.CodCircuito,
                            Circuito = ppj.Circuito,
                            Apellido = ppj.Apellido,
                            Nombre = ppj.Nombre,
                            ApellidoyNombres = ppj.ApellidoyNombres,
                            Genero = ppj.Genero,
                            Tipodocumento = ppj.Tipodocumento,
                            Matricula =  ppj.Matricula,
                            Fechanacimiento = (DateTime)ppj.Fechanacimiento,
                            Clase = (int)ppj.Clase,
                            DescTipoPadron = ppj.DescTipoPadron,
                            EstadoAfiliacion = ppj.EstadoAfiliacion,
                            FechaAfiliacion = (DateTime)ppj.FechaAfiliacion,
                            Analfabeto = ppj.Analfabeto,
                            Profesion = ppj.Profesion,
                            Fechadomicilio = (DateTime)ppj.Fechadomicilio,
                            Domicilio = ppj.Domicilio,
                            CUIL = psec.MAESOC_CUIL_STR


                          };


        return PadronSECPJ.ToList();
        ;
      }
    }

    public static string GetDDJJByEmpleado(string cuil)
    {
      using (var context = new lts_sindicatoDataContext())
      {

        var lastDJ = _DDJJ.Where(x => x.CUIL == cuil);

        if (lastDJ.Count() == 0)
        {
          return "SIN DDJJ";
        }
        else
        {
          return lastDJ.Max(x => x.Periodo).ToString("MM/yyyy");
        }
      }
    }

    public static List<mdlDDJJEmpleado> GetDDJJ()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        DateTime Desde = DateTime.Now.AddYears(-5);
        var Aportes = from a in context.ddjj
                      where a.periodo > Desde
                      select new mdlDDJJEmpleado
                      {
                        Cuit = a.CUIT_STR,
                        CUIL = a.CUIL_STR,
                        Periodo = (DateTime)a.periodo
                      };
        return Aportes.ToList();

      }
    }
  }
}
