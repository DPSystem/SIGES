using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Metodos
{
  internal class MtdOPI
  {
    public static int GetNroOP()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var OPI = from a in context.OPI.Where(x=>x.Egreso == 1) select a;
        if (OPI.Count() == 0)
        {
          return 1;
        }
        else
        {
          return (int)OPI.Max(x => x.Numero);
        }
      }
    }


    public static int GetNroOI()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var OPI = from a in context.OPI.Where(x => x.Ingreso == 1) select a;
        if (OPI.Count() == 0)
        {
          return 1;
        }
        else
        {
          return (int)OPI.Max(x => x.Numero);
        }
      }
    }



  }
}
