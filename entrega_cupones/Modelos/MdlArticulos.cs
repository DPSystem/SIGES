using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Modelos
{
  internal class MdlArticulos
  {
    public int Id { get; set; }
    public int Codigo { get; set; }
    public string Descripcion { get; set; }
    public string CodigoDeBarra  { get; set; }
    public int Cantidad { get; set; }
    public int Estado { get; set; }
    public string Sexo { get; set; }
    public int CodProv { get; set; }
    public int StockInicial { get; set; }
  }
}
