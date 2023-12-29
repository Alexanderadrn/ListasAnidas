using System;
using System.Collections.Generic;

namespace ListasAnidas.Models;

public partial class RelacionProviciaCiudad
{
    public int IdRelProvCiu { get; set; }

    public string? NombreProvincia { get; set; }

    public string? NombreCiudad { get; set; }
}
