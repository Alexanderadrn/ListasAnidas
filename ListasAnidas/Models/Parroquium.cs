using System;
using System.Collections.Generic;

namespace ListasAnidas.Models;

public partial class Parroquium
{
    public int IdParroquia { get; set; }

    public string? NombreParroquia { get; set; }

    public int? IdCiudad { get; set; }

    public virtual Ciudad? IdCiudadNavigation { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
