using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Modelos
{
  class mdlActa
  {
    public int NroActa { get; set; }
    public string Cuit { get; set; }
    public string RazonSocial { get; set; }
    public string Domicilio { get; set; }
    public DateTime? Desde { get; set; }
    public DateTime? Hasta { get; set; }
    public decimal Importe { get; set; }
    public int NroDePlan { get; set; }
    public int  Estado { get; set; }
    public DateTime? Fecha { get; set; }
    public DateTime? FechaVenc { get; set; }
    public int CantidadEmpleados { get; set; }
    public string TelefonoEmpresa { get; set; }
    public decimal InteresMensual { get; set; }
    public decimal InteresDiario { get; set; }
    public string Localidad { get; set; }
    public string CodigoPostal { get; set; }
    public DateTime InicioActividades { get; set; }
    public decimal Capital { get; set; }
    public decimal  Interes { get; set; }
    public decimal Total { get; set; }
    public int InspectorId { get; set; }
    public string InspectorNombre { get; set; }

  }
}
