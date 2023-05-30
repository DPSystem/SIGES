using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Modelos
{
  class MdlReservasQuinchos
  {
    public int? Id { get; set; }
    public DateTime? Fecha { get; set; }
    public int? QuinchoId { get; set; }
    public string NombreQuincho { get; set; }
    public int? Estado { get; set; }
    public string EstadoReserva { get; set; }
    public int? Capacidad { get; set; }
    public int? SocioId { get; set; }
    public string  SocioCuil { get; set; }
    public int? EventoId { get; set; }
    public int? CantiInvitados { get; set; }
    public int? CantTenedor { get; set; }
    public int? CantCuchillos { get; set; }
    public int? CantVasos { get; set; }
    public int? CantTablones { get; set; }
    public int? CantMesasRedondas { get; set; }
    public decimal? Costo { get; set; }
    public DateTime? FechaVencReserva { get; set; }
    public DateTime? FechaDeConfirmacion { get; set; }
    public DateTime? FechaDeCancelacion { get; set; }



  }
}
