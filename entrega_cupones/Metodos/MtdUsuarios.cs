using entrega_cupones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Metodos
{
  class MtdUsuarios
  {
    public  List<MdlUsuario> _Usuario;
    public static string GetUserById(int UsuarioId)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var usuario = from a in context.Usuarios where a.idUsuario == UsuarioId select a;
        if (usuario.Count() > 0)
        {
          return usuario.SingleOrDefault().Usuario;
        }
        else
        {
          return "";
        }
      }
    }

    public static bool GetUserByName(string Usuario)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var usuario = from a in context.Usuarios.Where(x => x.Usuario == Usuario) select a;
        return usuario.Count() > 0;
      }
    }

    public static bool GetUserByPwd(string Usuario, string Pwd)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var usuario = from a in context.Usuarios.Where(x => x.Usuario == Usuario) select a;

        return usuario.SingleOrDefault().Password == Pwd;

      }
    }
    public static List<MdlUsuario> GetUserModel(string Usuario)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var usuario = from a in context.Usuarios.Where(x => x.Usuario == Usuario)
                      select new MdlUsuario
                      {
                        UsrId = a.idUsuario,
                        UserName = a.Usuario
                      };
        return usuario.ToList();
        //return usuario.SingleOrDefault().Password == Pwd;

      }
    }
  }
}
