using Microsoft.Extensions.Primitives;

namespace ListasAnidas.viewmodels
{
    public class CiudadVM
    {
        public int idCiudad { get; set; }

        public string? nombreCiudad { get; set; }

        public int? idProvincia { get; set; }

        public string? nombreProvincia { get; set; }
    }
}
