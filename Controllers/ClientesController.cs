using hotel_clientes.DTO;
using hotel_clientes.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace hotel_clientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private ClientesService clientesService;
        public ClientesController(ClientesService servicio_cliente) {
            clientesService = servicio_cliente; 
        }
        [HttpGet("obtener_cliente")]
        public ActionResult ObtenerCliente([FromQuery]string rut_cliente)
        {
            try
            {
                var consulta = clientesService.GetCliente(rut_cliente);
                if (consulta == null) return NotFound(new ApiResponse(false,"No se encontro cliente",null,null));
                return Ok(new ApiResponse(true, "Cliente obtenido correctamente", consulta, null));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensaje = "Error interno del servidor" });
            }
        }
        [HttpGet("obtener_clientes")]
        public ActionResult ObtenerTodos()
        {
            var consulta = clientesService.GetClientes();
            if (consulta == null) return BadRequest(new ApiResponse(false,"Ha ocurrido un error",null,null));
            return Ok(new ApiResponse(true,"Clientes obtenidos correctamente",consulta,null));
        }
        [HttpPost("cambiar_telefono")]
        public ActionResult ObtenerCambiarTelefono([FromBody]ClienteTelefonoDTO cliente)
        {
            if (ModelState.IsValid)
            {
                var consulta = clientesService.ChangePhoneContact(cliente.rut_cliente, cliente.telefono);
                if (consulta == false) return BadRequest(new ApiResponse(false, "Ha ocurrido un error", null, null));
                return Ok(new ApiResponse(true,"Teléfono actualizado correctamente", consulta,null));
            }
            return BadRequest(new ApiResponse(false, "Los datos fueron incorrectos", null, null));
        }
        [HttpPost("cambiar_correo")]
        public ActionResult ObtenerCambiarCorreo([FromBody] ClienteCorreoDTO cliente)
        {
            if (ModelState.IsValid)
            {
                var consulta = clientesService.ChangeCorreoContact(cliente.rut_cliente, cliente.correo);
                if (consulta == false) return BadRequest(new ApiResponse(false, "Ha ocurrido un error", null, null));
                return Ok(new ApiResponse(true, "Correo actualizado correctamente", consulta, null));
            }
            return BadRequest(new ApiResponse(false, "Los datos fueron incorrectos", null, null));
        }
        [HttpPost("crear_cliente")]
        public ActionResult CrearCliente([FromBody]ClienteCrearDTO cliente)
        {
            if (ModelState.IsValid)
            {
                var resultado = clientesService.CreateCliente(cliente);
                if (resultado == false) return BadRequest(new ApiResponse(false, "Ha ocurrido un error", null, null));
                return Ok(new ApiResponse(true, "Cliente creado correctamente", null, null));
            }
            return BadRequest(new ApiResponse(false, "Los datos fueron incorrectos", null, null));
        }
    }
}
