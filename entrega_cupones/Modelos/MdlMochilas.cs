using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Modelos
{
  class MdlMochilas
  {
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public string CodigoDeBarra { get; set; }
    public int Cantidad { get; set; }
    public int Estado { get; set; }
    public string Sexo { get; set; }
    public string CodigoDelProveedor { get; set; }
    public int StockInicial { get; set; }

  }
}
