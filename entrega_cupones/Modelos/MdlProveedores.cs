using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Modelos
{
  internal class MdlProveedores
  {
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string CBU { get; set; }
    public string Alias { get; set; }
    public string Cuenta { get; set; }
    public int BancoId { get; set; }
    public int InformaVenc { get; set; }
    public DateTime  FechaAlta { get; set; }
    public int UsuarioId { get; set; }
    public int Estado { get; set; }

  }
}
