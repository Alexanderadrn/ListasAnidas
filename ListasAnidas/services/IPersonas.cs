using ListasAnidas.viewmodels;

namespace ListasAnidas.services
{
    public interface IPersonas
    {
        public List<PersonasVM> ObtenerPersonas();
        public bool setPersonas(PersonasVM personas);
        public bool putPersonas(PersonasVM personas);
        public bool deletePersonas(int id);

        public List<ProvinciaVM> ObtenerProvincias();
        public List<CiudadVM> ObtenerCiudad();
        public List<ParroquiaVM> ObtenerParroquia();
        public List<CiudadVM> ObtenerCiudadbyId(int id);
        public List<ParroquiaVM> ObtenerParroquiabyId(int id);
        public List<PersonasVM> ObtenerPersonasByProvincias(int id);
        public List<PersonasVM> ObtenerPersonasByCiudad(int id);
        public List<PersonasVM> ObtenerPersonasByParroquia(int id);
    }
}
