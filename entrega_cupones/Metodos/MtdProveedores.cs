using entrega_cupones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Metodos
{
  internal class MtdProveedores
  {
    public static List<MdlProveedores> GetProveedores()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var Proveedores =( from a in context.Proveedores
                           select new MdlProveedores
                           {
                             Id = a.Id,
                             Alias = a.Alias,
                             BancoId = (int)a.BancoId,
                             CBU = a.CBU,
                             Cuenta = a.Cuenta,
                             Estado = (int)a.Estado,
                             FechaAlta = (DateTime)a.FechaAlta,
                             InformaVenc = (int)a.InformaVenc,
                             Nombre = a.Nombre,
                             UsuarioId = (int)a.UsuarioId

                           }).OrderBy(x=>x.Nombre);
        return Proveedores.ToList();  
      }
    }
  }
}
