using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Modelos
{
  class MdlBenef
  {
    public int Id { get; set; }
    public string DNI { get; set; }
    public string ApeNom { get; set; }
    public DateTime FechaNac { get; set; }
    public int Edad { get; set; }
    public string  Parentesco { get; set; }
    public string Mochila { get; set; }
    public int? MochilaId { get; set; }
    public int CodigoFliar { get; set; }
    public int Estado { get; set; } // 0 - Sin Asignar // 1 - N° de Cupon // 2 - Entregado
    public DateTime? FechaGeneracionDeCupon { get; set; }
    public DateTime? FechaDeEntrega { get; set; }
    public int? NroCupon { get; set; }
    public int Reimpresion { get; set; }
  }
}
