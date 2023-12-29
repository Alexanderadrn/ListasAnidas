using System;
using System.Collections.Generic;

namespace ListasAnidas.Models;

public partial class Ciudad
{
    public int IdCiudad { get; set; }

    public string? NombreCiudad { get; set; }

    public int? IdProvincia { get; set; }

    public virtual Provincium? IdProvinciaNavigation { get; set; }

    public virtual ICollection<Parroquium> Parroquia { get; set; } = new List<Parroquium>();

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
