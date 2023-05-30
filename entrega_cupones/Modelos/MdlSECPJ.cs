using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Modelos
{
  internal class MdlSECPJ
  {
    public int CodSeccion { get; set; }
    public string Seccion { get; set; }
    public string CodCircuito { get; set; }
    public string Circuito { get; set; }
    public string Apellido { get; set; }
    public string Nombre { get; set; }
    public string ApellidoyNombres { get; set; }
    public string Genero { get; set; }
    public string Tipodocumento { get; set; }
    public string Matricula { get; set; }
    public DateTime Fechanacimiento { get; set; }
    public int Clase { get; set; }
    public string DescTipoPadron { get; set; }
    public string EstadoAfiliacion { get; set; }
    public DateTime FechaAfiliacion { get; set; }
    public string Analfabeto { get; set; }
    public string Profesion { get; set; }
    public DateTime Fechadomicilio { get; set; }
    public string Domicilio { get; set; }
    public string  CUIL { get; set; }
    public string RazonSocial { get; set; }

  }
}
