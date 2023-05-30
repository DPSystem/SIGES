using entrega_cupones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Metodos
{
  class MtdReservasQuinchos
  {
    public static List<MdlReservasQuinchos> _ReservaQuinchos = new List<MdlReservasQuinchos>();
    public static mdlSocio _Socio = new mdlSocio();

    public static List<MdlReservasQuinchos> GetReservasQuinchos(DateTime fecha)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        _ReservaQuinchos.Clear();

        //var rq1 = from a in context.reservas_quinchos.Where(x => x.Fecha.Date == fecha.Date && (x.Estado != 3 || x.Estado != 8 || x.Estado != 9)) select a;
        var rq1 = from a in context.reservas_quinchos.Where(x => x.Fecha.Date == fecha.Date && (x.Estado == 0 || x.Estado == 1 || x.Estado == 2)) select a;
        var q1 = from a in context.quinchos
                 join rqqq in rq1
                       on a.Id equals rqqq.QuinchoId
                       into rqq
                 from rq in rqq.DefaultIfEmpty()
                 select new MdlReservasQuinchos
                 {
                   Id = rq.Id,
                   QuinchoId = a.Id,
                   NombreQuincho = a.Nombre,
                   Estado = Convert.ToInt32(rq.Estado),
                   Capacidad = Convert.ToInt32(a.Capacidad),
                   Costo = Convert.ToDecimal(a.Costo),
                   FechaVencReserva = Convert.ToDateTime(rq.FechaVencReserva),
                   SocioId = rq.SocioId,
                   FechaDeConfirmacion = rq.FechaDeConfirmacion

                 };
        _ReservaQuinchos.AddRange(q1);
        _ReservaQuinchos.ToList().ForEach(x => x.EstadoReserva = GetEstadoReserva(Convert.ToInt32(x.Estado)));
        return _ReservaQuinchos.ToList();
      }
    }

    private static string GetEstadoReserva(int EstadoQuincho)
    {
      switch (EstadoQuincho)
      {
        case 0: return "Libre";
        case 1: return "Reservado";
        case 2: return "Confirmado";
        default: return "";
      }
    }

    public static void SetVencReserva()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        //Estado 8 de la reserva significa que esta vencido, es decir que reservaron pero no confirmaron
        context.reservas_quinchos.Where(x => x.FechaVencReserva < DateTime.Now && x.Estado == 1).ToList().ForEach(x => x.Estado = 8);
        context.SubmitChanges();
        //Estado 3 es evento finalizado, es decir que se realizo con normalidad y ya termino.
        context.reservas_quinchos.Where(x => x.FechaVencReserva < DateTime.Now && x.Estado == 2).ToList().ForEach(x => x.Estado = 3);
        context.SubmitChanges();
      }
    }

    public static void CancelarReserva(int ReservaId, int Estado)
    {
      if (Estado == 1 || Estado == 2)
      {
        using (var datacontext = new lts_sindicatoDataContext())
        {
          var cancel = datacontext.reservas_quinchos.Where(x => x.Id == ReservaId).Single();
          cancel.Estado = 9;
          cancel.FechaDeCancelacion = DateTime.Now;
          datacontext.SubmitChanges();
        }
      }
    }

    public static mdlSocio MostrarSocioQueAlquila(string SocioNro)
    {
      using (var context = new lts_sindicatoDataContext())
      {
        return mtdSocios.GetDatosDelSocioPorNroDeSocio(SocioNro);
      }
    }

    public static int GetLastNumberRereserva()
    {
      using (var context = new lts_sindicatoDataContext())
      {
        var NroAut = context.reservas_quinchos;
        return NroAut.Count() == 0 ? 0 : (Int32)NroAut.Max(x => x.Numero);
      }
    }

    public static int GetLastNroRecibo()
    {
      using (var context =  new lts_sindicatoDataContext())
      {
        var recibo = context.Recibos;
        return recibo.Count() > 0 ? (int )recibo.Max(x => x.NroAutomatico) : 0; 
      }
    }
  }
}
