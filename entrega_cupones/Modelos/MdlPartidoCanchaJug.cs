using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Modelos
{
  class MdlPartidoCanchaJug
  {

    public string equipo { get; set; }
    public DateTime fecha { get; set; }
    public TimeSpan hora { get; set; }
    public int fase { get; set; }
    public string cancha { get; set; }
    public string categoria { get; set; }
    public int partidoID { get; set; }
    public string col1NroSocio { get; set; }
    public string col1Nombre { get; set; }
    public double col1DNI { get; set; }
    public  Image col1Foto { get; set; }
    public int nroFecha { get; set; }
    public int sancion_x_de { get; set; }
    public int sancion_cantidad { get; set; }
    public int orden_fixture { get; set; }
    public string nom_campeonato { get; set; }
    public int año { get; set; }
    public int columna { get; set; }
    

  }
}
