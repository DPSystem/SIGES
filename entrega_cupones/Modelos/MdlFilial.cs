using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Modelos
{
  class MdlFilial
  {
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Domicilio { get; set; }
    public string Localidad { get; set; }
    public string Telefono { get; set; }
    public string Provincia { get; set; }
    public string email  { get; set; }
    public string  SecretearioGeneral { get; set; }
    public string SubSecretario { get; set; }
    public int SorteoConfig { get; set; }
    public decimal PorcentajeDescuentoLey { get; set; }
    public decimal PorcentajeDescuentoSocio { get; set; }
    public decimal InteresMensualPorMora { get; set; }
  }

}
