using entrega_cupones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Metodos
{
  class MtdPermisos
  {
    public static List<MdlPermisos> GetPermisosDeUsuario(int UserId)
    {

      using (var context = new lts_sindicatoDataContext ())
      {
        var permisos = from a in context.UsuariosObjetos
                       where a.UsuarioId == UserId
                       join obj in context.Objetos on a.ObjetoId equals obj.ID

                       select new MdlPermisos
                       {
                         UsusrioId = (int) a.UsuarioId,
                         ObjetoNombre = obj.Nombre,
                         ObjetoEstado = (int)a.Estado
                       };
        return permisos.ToList();
      }
    }
  }
}
