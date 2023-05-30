using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Modelos
{
  internal class Mdl_InformeDDJJCobrosActas
  {
    public DateTime Periodo { get; set; }
    public int Rectificacion { get; set; }
    public decimal ImporteDDJJ { get; set; }
    public decimal CobradoDDJJ { get; set; }
    public decimal ImporteDeActasGeneradas { get; set; }
    public decimal ImporteDeActasCobradas { get; set; }
    public decimal FaltaCobrar { get; set; }
    public decimal PorcentajeDeMora { get; set; }
    public List<MdlDeudaEmpresa> Empresas { get; set; }
  }
}

