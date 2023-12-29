using ListasAnidas.services;
using ListasAnidas.viewmodels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListasAnidas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        public IPersonas persona;

        public PersonasController(IPersonas _persona)
        {
            this.persona = _persona;
        }
        [HttpGet("ObtenerPersonas")]
        public ActionResult ObtenerEmpleados()
        {
            return new JsonResult(persona.ObtenerPersonas());
        }
        [HttpPost("SetPersonas")]
        public bool SetPersonas(PersonasVM personas)
        {
            return persona.setPersonas(personas);
        }
        [HttpPost("PutPersonas")]
        public bool PutPersonas(PersonasVM personas)
        {
            return persona.putPersonas(personas);
        }
        [HttpPost("DeletePersonas")]
        public bool DeletePersonas(int id)
        {
            return persona.deletePersonas(id);
        }

        [HttpGet("ObtenerProvincias")]
        public ActionResult ObtenerProvincias()
        {
            return new JsonResult(persona.ObtenerProvincias());
        }
        [HttpGet("ObtenerCiudades")]
        public ActionResult ObtenerCiudad()
        {
            return new JsonResult(persona.ObtenerCiudad());
        }
        [HttpGet("ObtenerParroquias")]
        public ActionResult ObtenerParroquia()
        {
            return new JsonResult(persona.ObtenerParroquia());
        }
        [HttpGet("ObtenerCiudadesbyId")]
        public ActionResult ObtenerCiudadbyId(int id)
        {
            return new JsonResult(persona.ObtenerCiudadbyId(id));
        }
        [HttpGet("ObtenerParroquiasbyId")]
        public ActionResult ObtenerParroquiabyId(int id)
        {
            return new JsonResult(persona.ObtenerParroquiabyId(id));
        }
        [HttpGet("ObtenerPersonasbyProvincia")]
        public ActionResult ObtenerParsonasbyProvincia(int id)
        {
            return new JsonResult(persona.ObtenerPersonasByProvincias(id));
        }
        [HttpGet("ObtenerPersonasbyCiudad")]
        public ActionResult ObtenerParsonasbyCiudad(int id)
        {
            return new JsonResult(persona.ObtenerPersonasByCiudad(id));
        }
        [HttpPost("ObtenerPersonasbyFiltros")]
        public ActionResult ObtenerPersonasFiltros(int provincia, int ciudad, int parroquia)
        {
            if (provincia == 0 && ciudad == 0 && parroquia == 0)
            {
                var result = persona.ObtenerPersonas();
                return new JsonResult(result);
            }
            if (provincia !=null && ciudad == 0 && parroquia == 0)
            {
                var result = persona.ObtenerPersonasByProvincias(provincia);
                return new JsonResult(result);
            }
            if (provincia != null &&ciudad != null && parroquia == 0)
            {
                var result = persona.ObtenerPersonasByCiudad(ciudad);
                return new JsonResult(result);
            }
            else
            {
                var result = persona.ObtenerPersonasByParroquia(parroquia);
                return new JsonResult(result);

            }

        }
    }
}
