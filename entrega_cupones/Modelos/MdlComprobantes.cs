using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Modelos
{
  internal class MdlComprobantes
  {
    public int Id { get; set; }
    public int CajaId { get; set; }
    public int TipoComprobanteId { get; set; }
    public int FormaPagoId { get; set; }
    public decimal Importe { get; set; }
    public string Comentario { get; set; }
    public int OPIId { get; set; }
    public DateTime FechaComprobante { get; set; }
    public int BancoId { get; set; }
    public string  NroCheque { get; set; }
    public DateTime   FechaEmision { get; set; }
    public DateTime FechaCobro { get; set; }
    public int NroTransf { get; set; }
    public DateTime FechaAlta { get; set; }
    public int Estado { get; set; }
    public int UsuarioId { get; set; }
  }
}
