using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Modelos
{
  internal class MdlCajas
  {
    public int Id { get; set; }
    public DateTime FechaApertura { get; set; }
    public int NroDeCaja { get; set; }
    public decimal SaldoInicial { get; set; }
    public decimal SaldoFinal { get; set; }
    public decimal Diferencia { get; set; }
    public int UserId { get; set; }
    public int Total { get; set; }
    public DateTime FechaCierre { get; set; }
    public int  UsuarioId { get; set; }

  }
}
