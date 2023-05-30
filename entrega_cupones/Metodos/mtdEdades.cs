using entrega_cupones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Metodos
{
  class mtdEdades
  {

    public static List<mdlMaeFlia> GenerarEdades()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var edades = (from a in context.maeflia
                      select new mdlMaeFlia
                      {
                        CodigoFliar = Convert.ToInt32(a.MAEFLIA_CODFLIAR),
                        Sexo = a.MAEFLIA_SEXO.ToString(),
                        Edad = mtdFuncUtiles.calcular_edad(a.MAEFLIA_FECNAC)
                      }).ToList();
        return edades;
      }
    }

    public static List<mdlEdades> GetEdades(int CodLoc)
    {

      using (var context = new lts_sindicatoDataContext())
      {
        

        var edades = (from a in context.soccen
                      join sf in context.socflia on a.SOCCEN_CUIL equals sf.SOCFLIA_CUIL
                      join flia in context.maeflia on sf.SOCFLIA_CODFLIAR equals flia.MAEFLIA_CODFLIAR
                      join maesocio in context.maesoc on a.SOCCEN_CUIL equals maesocio.MAESOC_CUIL
                      where a.SOCCEN_ESTADO == 1
                      //where a.SOCCEN_ESTADO == 1 && maesocio.MAESOC_CODPOS == "4220"
                      where a.SOCCEN_ESTADO == 1 && (CodLoc.ToString() == "0" ? maesocio.MAESOC_CODPOS != CodLoc.ToString() : maesocio.MAESOC_CODPOS == CodLoc.ToString())
                      select new
                      {
                        sexo = flia.MAEFLIA_SEXO.ToString(),
                        edad = mtdFuncUtiles.calcular_edad(flia.MAEFLIA_FECNAC)// calcular_edad(flia.MAEFLIA_FECNAC)
                      }).ToList();

        List<mdlEdades> ListEdades = new List<mdlEdades>();


        ListEdades.Add(new mdlEdades { Edad = "0", Varon = edades.Where(x => x.sexo == "F" && x.edad == 0).Count(), Mujer = edades.Where(x => x.sexo == "M" && x.edad == 0).Count(), Cantidad = 0 });
        ListEdades.Add(new mdlEdades { Edad = "1", Varon = edades.Where(x => x.sexo == "F" && x.edad == 1).Count(), Mujer = edades.Where(x => x.sexo == "M" && x.edad == 1).Count(), Cantidad = 0 });
        ListEdades.Add(new mdlEdades { Edad = "2", Varon = edades.Where(x => x.sexo == "F" && x.edad == 2).Count(), Mujer = edades.Where(x => x.sexo == "M" && x.edad == 2).Count(), Cantidad = 0 });
        ListEdades.Add(new mdlEdades { Edad = "3", Varon = edades.Where(x => x.sexo == "F" && x.edad == 3).Count(), Mujer = edades.Where(x => x.sexo == "M" && x.edad == 3).Count(), Cantidad = 0 });
        ListEdades.Add(new mdlEdades { Edad = "4", Varon = edades.Where(x => x.sexo == "F" && x.edad == 4).Count(), Mujer = edades.Where(x => x.sexo == "M" && x.edad == 4).Count(), Cantidad = 0 });
        ListEdades.Add(new mdlEdades { Edad = "5", Varon = edades.Where(x => x.sexo == "F" && x.edad == 5).Count(), Mujer = edades.Where(x => x.sexo == "M" && x.edad == 5).Count(), Cantidad = 0 });
        ListEdades.Add(new mdlEdades { Edad = "6", Varon = edades.Where(x => x.sexo == "F" && x.edad == 6).Count(), Mujer = edades.Where(x => x.sexo == "M" && x.edad == 6).Count(), Cantidad = 0 });
        ListEdades.Add(new mdlEdades { Edad = "7", Varon = edades.Where(x => x.sexo == "F" && x.edad == 7).Count(), Mujer = edades.Where(x => x.sexo == "M" && x.edad == 7).Count(), Cantidad = 0 });
        ListEdades.Add(new mdlEdades { Edad = "8", Varon = edades.Where(x => x.sexo == "F" && x.edad == 8).Count(), Mujer = edades.Where(x => x.sexo == "M" && x.edad == 8).Count(), Cantidad = 0 });
        ListEdades.Add(new mdlEdades { Edad = "9", Varon = edades.Where(x => x.sexo == "F" && x.edad == 9).Count(), Mujer = edades.Where(x => x.sexo == "M" && x.edad == 9).Count(), Cantidad = 0 });
        ListEdades.Add(new mdlEdades { Edad = "10", Varon = edades.Where(x => x.sexo == "F" && x.edad == 10).Count(), Mujer = edades.Where(x => x.sexo == "M" && x.edad == 10).Count(), Cantidad = 0 });
        ListEdades.Add(new mdlEdades { Edad = "11", Varon = edades.Where(x => x.sexo == "F" && x.edad == 11).Count(), Mujer = edades.Where(x => x.sexo == "M" && x.edad == 11).Count(), Cantidad = 0 });
        ListEdades.Add(new mdlEdades { Edad = "12", Varon = edades.Where(x => x.sexo == "F" && x.edad == 12).Count(), Mujer = edades.Where(x => x.sexo == "M" && x.edad == 12).Count(), Cantidad = 0 });

        return ListEdades;
      }
    }

  }
}
