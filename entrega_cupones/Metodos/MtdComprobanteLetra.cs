using entrega_cupones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Metodos
{
  internal class MtdComprobanteLetra
  {
    public static List<MdlTipoComprobante> GetLetraComprobantes()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var ComprobantesLetra = from a in context.TipoComprobanteLetra
                           select new MdlTipoComprobante
                           {
                             Id = a.Id,
                             Nombre = a.Letra,
                             FechaAlta = (DateTime)a.FechaAlta,
                             Estado = (int)a.Estado,
                             UsuarioId = (int)a.UsuarioId
                           };
        return ComprobantesLetra.OrderBy(x => x.Nombre).ToList();
      }

    }
  }
}
