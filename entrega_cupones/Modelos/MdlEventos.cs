using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Modelos
{
  class MdlEventos
  {
    public int Id { get; set; }
    public string  Nombre { get; set; }
    public int Estado { get; set; }
    public DateTime? Inicio { get; set; }
    public DateTime? Fin { get; set; }
    public DateTime? HoraFin { get; set; }


  }
}
