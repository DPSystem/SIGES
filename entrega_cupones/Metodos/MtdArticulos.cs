using entrega_cupones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Metodos
{
  internal class MtdArticulos
  {
    public static List<MdlArticulos> GetArticulosReserva()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var ListArt = (from a in context.articulos.Where(x => x.ReservaQuinchoId == 1)
                      select new MdlArticulos
                      {
                        Id = a.ID,
                        Descripcion = a.Descripcion,
                        Cantidad = 0
                      }).OrderBy(x=>x.Descripcion);
        return ListArt.ToList();
      }
    }
  }
}
