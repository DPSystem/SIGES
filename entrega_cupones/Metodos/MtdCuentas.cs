using entrega_cupones.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Metodos
{
  internal class MtdCuentas
  {
    public static List<MdlCuentas> GetCuentas()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var Cuentas = (from a in context.Cuentas
                      select new MdlCuentas
                      {
                        Id = a.Id,
                        Estado = (int)a.Estado,
                        FechaAlta = (DateTime)a.FechaAlta,
                        FechaBaja = (DateTime)a.FechaBaja,
                        IngresoEgreso = (int)a.IngresoEgreso,
                        Nombre = a.Nombre,
                        UsuarioId = (int)a.UsuarioId

                      }).OrderBy(x=>x.Nombre);
        return Cuentas.ToList();
      }
    }
  }
}
