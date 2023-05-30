using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Modelos
{
  class MdlCuponesEmitidos
  {
    public int NroCupon { get; set; }
    public string Socio { get; set; }
    public DateTime? FechaEntrega { get; set; }
    public int Edad { get; set; }
    public string Sexo { get; set; }
    public int Cantidad { get; set; }
    public int Varon { get; set; }
    public int Mujer { get; set; }
    public int Invitado { get; set; }
    public int  InvitacionEspecial { get; set; }
    public int  Total { get; set; }
    public int UsuarioId { get; set; }
    public string UsuarioNombre  { get; set; }

  }
}
