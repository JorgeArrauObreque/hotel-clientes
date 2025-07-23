using hotel_clientes.DTO;
using hotel_clientes.Models;
using hotel_clientes.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace hotel_clientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizacionController : ControllerBase
    {
        private LocalizacionesServices _localizacionesService;
        public LocalizacionController(LocalizacionesServices localizacion_service) 
        {
            this._localizacionesService = localizacion_service;
        }
        [HttpGet("obtener_comunas")]
        public ActionResult ObtenerComunasCiudad([FromQuery]int ciudad)
        {
            var comunas = _localizacionesService.GetComunasCiudad(ciudad);
            return Ok(new ApiResponse(true, "Regiones obtenidas correctamente", comunas, null));
        }
        [HttpGet("obtener_ciudades")]
        public ActionResult ObtenerCiudades()
        {
            var ciudades = _localizacionesService.GetCiudades();
            return Ok(new ApiResponse(true,"Regiones obtenidas correctamente",ciudades,null));
        }
        [HttpGet("obtener_ciudades_comunas")]
        public ActionResult ObtenerCiudadesComunas()
        {
            var ciudades = _localizacionesService.GetCiudadesComunas();
            return Ok(new ApiResponse(true, "Regiones obtenidas correctamente", ciudades, null));
        }
    }
}
