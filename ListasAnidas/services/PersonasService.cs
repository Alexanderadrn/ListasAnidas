using ListasAnidas.Models;
using ListasAnidas.viewmodels;

namespace ListasAnidas.services
{
    public class PersonasService : IPersonas
    {
        private ListasanidadasContext _context;

        public PersonasService(ListasanidadasContext context)
        {
            this._context = context;
        }

        #region Personas 
        public List<PersonasVM> ObtenerPersonas()
        {
            List<PersonasVM> listPersonas = new List<PersonasVM>();
            var personas = (from persona in _context.Personas
                            join provincias in _context.Provincia
                            on persona.IdProvincia equals provincias.IdProvincias
                            join ciudad in _context.Ciudads
                            on persona.IdCiudad equals ciudad.IdCiudad
                            join parroquia in _context.Parroquia
                            on persona.IdParroquia equals parroquia.IdParroquia
                            where persona.IdPersonas != 0
                            select new
                            {
                                persona.IdPersonas,
                                persona.NombrePersona,
                                persona.CedulaPersonas,
                                provincias.IdProvincias,
                                provincias.NombreProvincia,
                                ciudad.IdCiudad,
                                ciudad.NombreCiudad,
                                parroquia.IdParroquia,
                                parroquia.NombreParroquia
                            }
                            ).ToList();
            foreach (var persona in personas)
            {
                PersonasVM registro = new PersonasVM
                {
                    idPersonas = persona.IdPersonas,
                    nombrePersona = persona.NombrePersona,
                    cedulaPersonas = persona.CedulaPersonas,
                    idProvincia = persona.IdProvincias,
                    nombreProvincia = persona.NombreProvincia,
                    idCiudad = persona.IdCiudad,
                    nombreCiudad = persona.NombreCiudad,
                    idParroquia = persona.IdParroquia,
                    nombreParroquia = persona.NombreParroquia

                };
                listPersonas.Add(registro);
            }
            return listPersonas;

        }

        public bool setPersonas(PersonasVM personas)
        {
            bool registrado = false;
            try
            {
                Persona personaBD = new Persona();
                personaBD.NombrePersona = personas.nombrePersona;
                personaBD.CedulaPersonas = personas.cedulaPersonas;
                personaBD.IdProvincia = personas.idProvincia;
                personaBD.IdCiudad = personas.idCiudad;
                personaBD.IdParroquia = personas.idParroquia;

                _context.Personas.Add(personaBD);
                _context.SaveChanges();
                registrado = true;

            }
            catch
            {
                registrado = false;
            }
            return registrado;
        }
        public bool putPersonas(PersonasVM personas)
        {
            bool registrado = false;
            var putPersonas = _context.Personas.Where(x => x.IdPersonas == personas.idPersonas).FirstOrDefault();
            try
            {
                putPersonas.NombrePersona = personas.nombrePersona;
                putPersonas.CedulaPersonas = personas.cedulaPersonas;
                putPersonas.IdProvincia = personas.idProvincia;
                putPersonas.IdCiudad = personas.idCiudad;
                putPersonas.IdParroquia = personas.idParroquia;
                _context.SaveChanges();
                registrado = true;
            }
            catch
            {
                registrado = false;
            }
            return registrado;
        }
        public bool deletePersonas(int id)
        {
            bool registrado = false;
            var deletePersonas = _context.Personas.Where(x => x.IdPersonas == id).FirstOrDefault();
            try
            {
                _context.Personas.Remove(deletePersonas);
                _context.SaveChanges();
                registrado = true;
            }
            catch
            {
                registrado = false;
            }
            return registrado;
        }

        #endregion

        #region Localidad
        public List<ProvinciaVM> ObtenerProvincias()
        {
            List<ProvinciaVM> listaProvincias = new List<ProvinciaVM>();
            var provincias = _context.Provincia.ToList();
            foreach (var item in provincias)
            {
                ProvinciaVM provincia = new ProvinciaVM
                {
                    idProvincias = item.IdProvincias,
                    nombreProvincia = item.NombreProvincia,
                };
                listaProvincias.Add(provincia);
            }
            return listaProvincias;
        }

        public List<CiudadVM> ObtenerCiudad()
        {
            List<CiudadVM> listCiudad = new List<CiudadVM>();
            var ciudades = (from ciudad in _context.Ciudads
                            join provincia in _context.Provincia
                            on ciudad.IdProvincia equals provincia.IdProvincias
                            where ciudad.IdCiudad != 0
                            select new
                            {
                                ciudad.IdCiudad,
                                provincia.IdProvincias,
                                provincia.NombreProvincia,
                                ciudad.NombreCiudad
                            }
                           ).ToList();
            foreach (var ciudad in ciudades)
            {
                CiudadVM registro = new CiudadVM
                {
                    idCiudad = ciudad.IdCiudad,
                    idProvincia = ciudad.IdProvincias,
                    nombreProvincia = ciudad.NombreProvincia,
                    nombreCiudad = ciudad.NombreCiudad

                };
                listCiudad.Add(registro);
            }
            return listCiudad;
        }
        public List<ParroquiaVM> ObtenerParroquia()
        {
            List<ParroquiaVM> listParroquia = new List<ParroquiaVM>();
            var parroquias = (from parroquia in _context.Parroquia
                              join ciudad in _context.Ciudads
                              on parroquia.IdCiudad equals ciudad.IdCiudad
                              where parroquia.IdParroquia != 0
                              select new
                              {
                                  parroquia.IdParroquia,
                                  ciudad.IdCiudad,
                                  ciudad.NombreCiudad,
                                  parroquia.NombreParroquia
                              }
                           ).ToList();
            foreach (var parroquia in parroquias)
            {
                ParroquiaVM registro = new ParroquiaVM
                {
                    idParroquia = parroquia.IdParroquia,
                    idCiudad = parroquia.IdCiudad,
                    nombreCiudad = parroquia.NombreCiudad,
                    nombreParroquia = parroquia.NombreParroquia

                };
                listParroquia.Add(registro);
            }
            return listParroquia;
        }

        public List<CiudadVM> ObtenerCiudadbyId(int id)
        {
            List<CiudadVM> listCiudad = new List<CiudadVM>();
            var ciudades = (from ciudad in _context.Ciudads
                            join provincia in _context.Provincia
                            on ciudad.IdProvincia equals provincia.IdProvincias
                            where id == provincia.IdProvincias
                            select new
                            {
                                ciudad.IdCiudad,
                                provincia.IdProvincias,
                                provincia.NombreProvincia,
                                ciudad.NombreCiudad
                            }
                           ).ToList();
            foreach (var ciudad in ciudades)
            {
                CiudadVM registro = new CiudadVM
                {
                    idCiudad = ciudad.IdCiudad,
                    idProvincia = ciudad.IdProvincias,
                    nombreProvincia = ciudad.NombreProvincia,
                    nombreCiudad = ciudad.NombreCiudad

                };
                listCiudad.Add(registro);
            }
            return listCiudad;
        }
        public List<ParroquiaVM> ObtenerParroquiabyId(int id)
        {
            List<ParroquiaVM> listParroquia = new List<ParroquiaVM>();
            var parroquias = (from parroquia in _context.Parroquia
                              join ciudad in _context.Ciudads
                              on parroquia.IdCiudad equals ciudad.IdCiudad
                              where id == ciudad.IdCiudad
                              select new
                              {
                                  parroquia.IdParroquia,
                                  ciudad.IdCiudad,
                                  ciudad.NombreCiudad,
                                  parroquia.NombreParroquia
                              }
                           ).ToList();
            foreach (var parroquia in parroquias)
            {
                ParroquiaVM registro = new ParroquiaVM
                {
                    idParroquia = parroquia.IdParroquia,
                    idCiudad = parroquia.IdCiudad,
                    nombreCiudad = parroquia.NombreCiudad,
                    nombreParroquia = parroquia.NombreParroquia

                };
                listParroquia.Add(registro);
            }
            return listParroquia;
        }

        public List<PersonasVM> ObtenerPersonasByProvincias(int id)
        {
            List<PersonasVM> listPersonas = new List<PersonasVM>();
            var personas = (from persona in _context.Personas
                            join provincias in _context.Provincia
                            on persona.IdProvincia equals provincias.IdProvincias
                            join ciudad in _context.Ciudads
                            on persona.IdCiudad equals ciudad.IdCiudad
                            join parroquia in _context.Parroquia
                            on persona.IdParroquia equals parroquia.IdParroquia
                            where provincias.IdProvincias == id
                            select new
                            {
                                persona.IdPersonas,
                                persona.NombrePersona,
                                persona.CedulaPersonas,
                                provincias.IdProvincias,
                                provincias.NombreProvincia,
                                ciudad.IdCiudad,
                                ciudad.NombreCiudad,
                                parroquia.IdParroquia,
                                parroquia.NombreParroquia
                            }
                            ).ToList();
            foreach (var persona in personas)
            {
                PersonasVM registro = new PersonasVM
                {
                    idPersonas = persona.IdPersonas,
                    nombrePersona = persona.NombrePersona,
                    cedulaPersonas = persona.CedulaPersonas,
                    idProvincia = persona.IdProvincias,
                    nombreProvincia = persona.NombreProvincia,
                    idCiudad = persona.IdCiudad,
                    nombreCiudad = persona.NombreCiudad,
                    idParroquia = persona.IdParroquia,
                    nombreParroquia = persona.NombreParroquia

                };
                listPersonas.Add(registro);
            }
            return listPersonas;
        }
        public List<PersonasVM> ObtenerPersonasByCiudad(int id)
        {
            List<PersonasVM> listPersonas = new List<PersonasVM>();
            var personas = (from persona in _context.Personas
                            join provincias in _context.Provincia
                            on persona.IdProvincia equals provincias.IdProvincias
                            join ciudad in _context.Ciudads
                            on persona.IdCiudad equals ciudad.IdCiudad
                            join parroquia in _context.Parroquia
                            on persona.IdParroquia equals parroquia.IdParroquia
                            where ciudad.IdCiudad == id
                            select new
                            {
                                persona.IdPersonas,
                                persona.NombrePersona,
                                persona.CedulaPersonas,
                                provincias.IdProvincias,
                                provincias.NombreProvincia,
                                ciudad.IdCiudad,
                                ciudad.NombreCiudad,
                                parroquia.IdParroquia,
                                parroquia.NombreParroquia
                            }
                            ).ToList();
            foreach (var persona in personas)
            {
                PersonasVM registro = new PersonasVM
                {
                    idPersonas = persona.IdPersonas,
                    nombrePersona = persona.NombrePersona,
                    cedulaPersonas = persona.CedulaPersonas,
                    idProvincia = persona.IdProvincias,
                    nombreProvincia = persona.NombreProvincia,
                    idCiudad = persona.IdCiudad,
                    nombreCiudad = persona.NombreCiudad,
                    idParroquia = persona.IdParroquia,
                    nombreParroquia = persona.NombreParroquia

                };
                listPersonas.Add(registro);
            }
            return listPersonas;
        }
        public List<PersonasVM> ObtenerPersonasByParroquia(int id)
        {
            List<PersonasVM> listPersonas = new List<PersonasVM>();
            var personas = (from persona in _context.Personas
                            join provincias in _context.Provincia
                            on persona.IdProvincia equals provincias.IdProvincias
                            join ciudad in _context.Ciudads
                            on persona.IdCiudad equals ciudad.IdCiudad
                            join parroquia in _context.Parroquia
                            on persona.IdParroquia equals parroquia.IdParroquia
                            where parroquia.IdParroquia == id
                            select new
                            {
                                persona.IdPersonas,
                                persona.NombrePersona,
                                persona.CedulaPersonas,
                                provincias.IdProvincias,
                                provincias.NombreProvincia,
                                ciudad.IdCiudad,
                                ciudad.NombreCiudad,
                                parroquia.IdParroquia,
                                parroquia.NombreParroquia
                            }
                            ).ToList();
            foreach (var persona in personas)
            {
                PersonasVM registro = new PersonasVM
                {
                    idPersonas = persona.IdPersonas,
                    nombrePersona = persona.NombrePersona,
                    cedulaPersonas = persona.CedulaPersonas,
                    idProvincia = persona.IdProvincias,
                    nombreProvincia = persona.NombreProvincia,
                    idCiudad = persona.IdCiudad,
                    nombreCiudad = persona.NombreCiudad,
                    idParroquia = persona.IdParroquia,
                    nombreParroquia = persona.NombreParroquia

                };
                listPersonas.Add(registro);
            }
            return listPersonas;
        }
        #endregion
    }
}
