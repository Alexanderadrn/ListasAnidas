using System;
using System.Collections.Generic;

namespace ListasAnidas.Models;

public partial class RelacionCiudadParroquium
{
    public int IdRelCiuParr { get; set; }

    public string? NombreProvincia { get; set; }

    public string? NombreCiudad { get; set; }

    public string? NombreParroquia { get; set; }
}
