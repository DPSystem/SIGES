using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Modelos
{
  internal class MdlCajaMovs
  {
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public int OPId { get; set; }
    public decimal Ingreso { get; set; }
    public decimal Egreso { get; set; }
    public decimal Saldo { get; set; }
    public int CajaId { get; set; }

  }
}
