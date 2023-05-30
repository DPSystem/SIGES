using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Modelos
{
  internal class MdlOPI
  {
    public int Id { get; set; }
    public decimal Importe { get; set; }
    public int Estado { get; set; }
    public decimal Ingreso { get; set; }
    public decimal Egreso { get; set; }
    public int CajaId { get; set; }
    public DateTime Fecha { get; set; }
    public int UsuarioId { get; set; }
  }
}
