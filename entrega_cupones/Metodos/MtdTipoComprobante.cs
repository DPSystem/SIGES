using entrega_cupones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Metodos
{
  internal class MtdTipoComprobante
  {
    public static List<MdlTipoComprobante> GetComprobantes()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var Comprobantes = from a in context.TipoComprobante
                           select new MdlTipoComprobante
                           {
                             Id = a.Id,
                             Nombre = a.Nombre,
                             FechaAlta = (DateTime)a.FechaAlta,
                             Estado = (int)a.Estado,
                             UsuarioId = (int)a.UsuarioId
                           };
        return Comprobantes.OrderBy(x => x.Nombre).ToList();
      }

    }

   
  }
}
