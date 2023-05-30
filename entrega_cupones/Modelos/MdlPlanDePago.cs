using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Modelos
{
  internal class MdlPlanDePago
  {
    public DateTime Fecha { get; set; }
    public int NroDePlan { get; set; }
    public string CUIT { get; set; }
    public int NroVD { get; set; }
    public int Estado { get; set; }
    public int NroDeActa { get; set; }
    public int UsuarioId { get; set; }

  }
}
