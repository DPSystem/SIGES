using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Modelos
{
  class MdlEventosAño
  {
    public int Id { get; set; }
    public int EventoId { get; set; }
    public int Año { get; set; }
    public int Estado { get; set; }
    public int UserId { get; set; }
    public string Lugarfecha { get; set; }
    public string Comentario { get; set; }
    public string NombreEvento { get; set; }
    public int EdadDesde { get; set; }
    public int  EdadHasta { get; set; }
  }
}
