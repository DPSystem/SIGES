using entrega_cupones.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Metodos
{
  class MtdEventos
  {
    public static List<MdlEventos> get_todos()
    {
      using (lts_sindicatoDataContext context = new lts_sindicatoDataContext())
      {
        var eventos_ = from a in context.eventos
                       where a.eventos_estado == 1
                       orderby a.eventos_nombre
                       select new MdlEventos
                       {
                         Id = a.eventos_id,
                         Nombre = a.eventos_nombre,
                         Estado = a.eventos_estado,
                       };
        return eventos_.ToList();
      }
    }

    public static List<MdlEventosAño> Get_EventoAño(int EventoId)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var EventoDato = from a in context.EventosAño.Where(x => x.EventoId == EventoId)
                         select new MdlEventosAño
                         {
                           Id = a.Id,
                           EventoId = Convert.ToInt32(a.EventoId),
                           Año = Convert.ToInt32(a.Año),
                           Estado = Convert.ToInt32(a.Estado),
                           UserId = Convert.ToInt32(a.UserId),
                           Lugarfecha = a.LugarFecha,
                           Comentario = a.Comentario,
                           NombreEvento = a.NombreEvento
                         };
        return EventoDato.ToList();
      }
    }

    public static DataTable Get_EventoAñoDt(int EventoId)
    {
      using (var context = new lts_sindicatoDataContext())
      {

        var EventoDato = from a in context.EventosAño.Where(x => x.EventoId == EventoId)
                         select new MdlEventosAño
                         {
                           Id = a.Id,
                           EventoId = Convert.ToInt32(a.EventoId),
                           Año = Convert.ToInt32(a.Año),
                           Estado = Convert.ToInt32(a.Estado),
                           UserId = Convert.ToInt32(a.UserId),
                           Lugarfecha = a.LugarFecha,
                           Comentario = a.Comentario,
                           NombreEvento = a.NombreEvento
                         };

        DS_cupones ds = new DS_cupones();
        DataTable dt = ds.EventosAño;
        dt.Clear();

        DataRow row = dt.NewRow();
        row["EventoId"] = EventoDato.Single().EventoId;
        row["Año"] = EventoDato.Single().Año;
        row["Estado"] = EventoDato.Single().Estado;
        row["UserId"] = EventoDato.Single().UserId;
        row["LugarFecha"] = EventoDato.Single().Lugarfecha;
        row["Comentario"] = EventoDato.Single().Comentario;
        row["NombreEvento"] = EventoDato.Single().NombreEvento;
        dt.Rows.Add(row);
        return dt;
      }
    }

    public static bool GetCuponGenerado(int EventoId, string Cuil)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var Cupon = from a in context.eventos_cupones.Where(x => x.eventcupon_evento_id == EventoId && x.CuilStr == Cuil) select a;
        if (Cupon.Count() > 0)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    public static List<MdlCuponesEmitidos> GetCuponesEmitidos(int EventoId)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var CuponesEmitidos = from a in context.eventos_cupones.Where(x => x.eventcupon_evento_id == EventoId)
                              join soc in context.maesoc on a.CuilStr equals soc.MAESOC_CUIL_STR
                              orderby a.event_cupon_nro
                              select new MdlCuponesEmitidos
                              {
                                NroCupon = a.event_cupon_nro,
                                Socio = soc.APENOM + (a.Invitado == 1 ? " - INVITADA" : ""),
                                FechaEntrega = a.event_cupon_fecha
                              };

        return CuponesEmitidos.ToList();
      }
    }

    public static List<MdlCuponesEmitidos> GetCuponesEmitidos_(int EventoId, int Filtro, DateTime Fecha)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        if (Filtro == 0)
        {
          var CuponesEmitidos = from a in context.EventosCupones_
                                where a.EventoAnioId == EventoId
                                join soc in context.maesoc on a.CuilTitular equals soc.MAESOC_CUIL_STR
                                join usr in context.Usuarios on a.UsuarioId equals usr.idUsuario
                                orderby a.NroCupon descending
                                select new MdlCuponesEmitidos
                                {
                                  NroCupon = (int)a.NroCupon,
                                  Socio = soc.APENOM + (a.Invitado == 1 ? " - INVITADO" : ""),
                                  FechaEntrega = a.FechaGeneracion,
                                  Invitado = (int)a.Invitado,
                                  UsuarioId = usr.idUsuario,
                                  UsuarioNombre = usr.Usuario
                                };
          return CuponesEmitidos.ToList();
        }
        else
        {
          var CuponesEmitidos = from a in context.EventosCupones_
                                where a.EventoAnioId == EventoId && Convert.ToDateTime(a.FechaGeneracion).Date == Fecha.Date
                                join soc in context.maesoc on a.CuilTitular equals soc.MAESOC_CUIL_STR
                                join usr in context.Usuarios on a.UsuarioId equals usr.idUsuario
                                orderby a.NroCupon descending
                                select new MdlCuponesEmitidos
                                {
                                  NroCupon = (int)a.NroCupon,
                                  Socio = soc.APENOM + (a.Invitado == 1 ? " - INVITADO" : ""),
                                  FechaEntrega = a.FechaGeneracion,
                                  Invitado = (int)a.Invitado,
                                  UsuarioId = usr.idUsuario,
                                  UsuarioNombre = usr.Usuario
                                };
          return CuponesEmitidos.ToList();

          //( a.EventoAnioId == EventoId) && 
        }



      }
    }

    public static int GetNroCuponEmitido(int EventoId, string Cuil)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        return (from a in context.eventos_cupones.Where(x => x.eventcupon_evento_id == EventoId && x.CuilStr == Cuil) select a).SingleOrDefault().event_cupon_nro;
      }
    }

    public static int GetEventoAñoId(int EventoId)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var EventoAño = from a in context.EventosAño.Where(x => x.EventoId == EventoId && x.Estado == 1) select a;

        return EventoAño.Count() > 0 ? EventoAño.SingleOrDefault().Id : 0;
      }
    }

    public static List<MdlEventosAño> GetListEventoAño(int EventoId)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var EventoAño = from a in context.EventosAño.Where(x => x.EventoId == EventoId)
                        select new MdlEventosAño
                        {
                          Id = a.Id,
                          Año = Convert.ToInt32(a.Año),
                          EventoId = Convert.ToInt32(a.EventoId),
                          Estado = Convert.ToInt32(a.Estado),
                          Comentario = a.Comentario,
                          Lugarfecha = a.LugarFecha,
                          NombreEvento = a.NombreEvento,
                          UserId = Convert.ToInt32(a.UserId)
                        };
        return EventoAño.ToList();
      }
    }

    public static bool InsertEventoAño(int EventoId, int Año, int Estado, int UserId, string LugarFecha, string Comentario, string NombreEveto, int ABM)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        try
        {
          if (ABM == 1)
          {
            EventosAño evento = new EventosAño
            {
              EventoId = EventoId,
              Año = Año,
              Estado = Estado,
              UserId = UserId,
              LugarFecha = LugarFecha,
              Comentario = Comentario,
              NombreEvento = NombreEveto
            };

            context.EventosAño.InsertOnSubmit(evento);
          }
          else
          {
            // var EventoUpdate = context.EventosAño.Where(x => x.id);
          }

          context.SubmitChanges();

          return true;

        }
        catch (Exception)
        {
          throw;
        }
      }
    }

    public static bool ContolarAño(int ABM, int EventoId, int año)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        return ABM == 3 ? true : context.EventosAño.Where(x => x.EventoId == EventoId && x.Año == año).Count() > 0;
      }
    }

    public static bool InsertEvento(string nombre)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        eventos evento = new eventos
        {
          eventos_estado = 1,
          eventos_nombre = nombre
        };
        try
        {
          context.eventos.InsertOnSubmit(evento);
          context.SubmitChanges();
          return true;
        }
        catch (Exception)
        {
          throw;

        }
      }
    }

    public static int GetUltimoNroDeCupon(int EventoAñoId)
    {

      using (var context = new lts_sindicatoDataContext())
      {
        try
        {
          var ultimo = from a in context.EventosCupones_.Where(x => x.EventoAnioId == EventoAñoId) select a;
          return ultimo.Count() > 0 ? (int)ultimo.Max(x => x.NroCupon) : 0;
        }
        catch (Exception)
        {
          throw;
        }
      }

    }

    public static int GetCuponGenerado_(int EventoAñoId, string CodFliar)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var CuponGenerado = from a in context.EventosCupones_ where a.EventoAnioId == EventoAñoId && a.CodigoFamiliar == CodFliar select a;
        return CuponGenerado.Count() > 0 ? -1 : 0;
      }
    }

    public static int GetCuponGeneradoDDEDC(int EventoAñoId, string Cuil)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var CuponGenerado = from a in context.EventosCupones_ where a.EventoAnioId == EventoAñoId && a.CuilTitular == Cuil && a.Invitado == 0 & a.InvitacionEspecial == 0 select a;
        return CuponGenerado.Count() > 0 ? (int)CuponGenerado.SingleOrDefault().NroCupon : 0;
      }
    }

    public static List<MdlCuponesEmitidos> GetCuponesEmitidosPorEdad()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var CuponesEmitidos = from a in context.EventosCupones_.Where(x => x.EventoAnioId == 3)
                              join mf in context.maeflia on a.CodigoFamiliar equals Convert.ToString(mf.MAEFLIA_CODFLIAR)

                              select new MdlCuponesEmitidos
                              {
                                NroCupon = (int)a.NroCupon,
                                FechaEntrega = a.FechaGeneracion,
                                Edad = mtdFuncUtiles.calcular_edad(mf.MAEFLIA_FECNAC),
                                Sexo = mf.MAEFLIA_SEXO.ToString()
                              };
        var grupo = CuponesEmitidos.GroupBy(x => x.Edad);

        return CuponesEmitidos.ToList();

      }
    }
  }
}
