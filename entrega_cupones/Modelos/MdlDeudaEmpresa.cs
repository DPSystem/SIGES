using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Modelos
{
  class MdlDeudaEmpresa
  {
    public int EstContId { get; set; }
    public string EstudioNombre { get; set; }
    public string CUIT { get; set; }
    public string Empresa { get; set; }
    public decimal Deuda { get; set; }
    public string EstudioDomicilio { get; set; }
    public string  EstudioTelefono { get; set; }
    public string  EstudioEmail { get; set; }
    public int Rectificacion { get; set; }
    public DateTime Periodo { get; set; }

  }
  
}
