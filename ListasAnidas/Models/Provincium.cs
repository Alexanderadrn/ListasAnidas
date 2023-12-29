using System;
using System.Collections.Generic;

namespace ListasAnidas.Models;

public partial class Provincium
{
    public int IdProvincias { get; set; }

    public string? NombreProvincia { get; set; }

    public virtual ICollection<Ciudad> Ciudads { get; set; } = new List<Ciudad>();

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
