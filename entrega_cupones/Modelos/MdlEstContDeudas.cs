using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Modelos
{
  class MdlEstContDeudas
  {
    public string EstContNombre { get; set; }
    public string  Domicilio { get; set; }
    public string  Telefono { get; set; }
    public string Email { get; set; }
    public List<MdlDeudaEmpresa> EmpresasConDeuda { get; set; }
  }
}
