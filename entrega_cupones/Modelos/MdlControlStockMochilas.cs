using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Modelos
{
  class MdlControlStockMochilas
  {
    public int Id { get; set; }
    public string Mochila { get; set; }
    public int ParaEntregar { get; set; }
    public int Entregadas { get; set; }
    public int EnStock { get; set; }
  }
}
