using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Modelos
{
  internal class MdlTipoComprobante
  {
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Estado { get; set; }
    public DateTime FechaAlta { get; set; }
    public int UsuarioId { get; set; }
  }
}
