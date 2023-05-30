using entrega_cupones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Metodos
{
  internal class MtdBancos
  {
    public static List<mdlBancos> GetBancos()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var Bancos = from a in context.Bancos
                           select new mdlBancos
                           {
                             Id =(int) a.BAN_ID,
                             Nombre = a.BAN_NOMBRE + " " + a.BAN_SUCURSAL
                           };
        return Bancos.OrderBy(x => x.Nombre).ToList();
      }

    }
  }
}
