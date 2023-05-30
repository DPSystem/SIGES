﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_cupones.Modelos
{
  internal class MdlCuentas
  {
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int IngresoEgreso { get; set; }
    public DateTime FechaAlta { get; set; }
    public DateTime? FechaBaja { get; set; }
    public int Estado { get; set; }
    public int UsuarioId { get; set; }
  }
}
