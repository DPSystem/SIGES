using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Modelos
{
    internal class MdlPlanDePagoDetalle
    {
    public int NroPlanDePago { get; set; }
    public int Cuota { get; set; }
    public decimal ImporteDeCuota { get; set; }
    public DateTime FechaDeVenc { get; set; }
  }
}
