using System;
using System.Collections.Generic;

namespace ListasAnidas.Models;

public partial class Persona
{
    public int IdPersonas { get; set; }

    public string? CedulaPersonas { get; set; }

    public int? IdProvincia { get; set; }

    public int? IdCiudad { get; set; }

    public int? IdParroquia { get; set; }

    public string? NombrePersona { get; set; }

    public virtual Ciudad? IdCiudadNavigation { get; set; }

    public virtual Parroquium? IdParroquiaNavigation { get; set; }

    public virtual Provincium? IdProvinciaNavigation { get; set; }
}
