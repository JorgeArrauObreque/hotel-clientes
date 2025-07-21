using hotel_clientes.DTO;
using hotel_clientes.Servicios;
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
            var consulta = clientesService.GetCliente(rut_cliente);
            return Ok(consulta);
        }
        [HttpGet("obtener_clientes")]
        public ActionResult ObtenerTodos()
        {
            var consulta = clientesService.GetClientes();
            return Ok(consulta);
        }
        [HttpPost("cambiar_telefono")]
        public ActionResult ObtenerCambiarTelefono([FromBody]ClienteTelefonoDTO cliente)
        {
            if (ModelState.IsValid)
            {
                var consulta = clientesService.ChangePhoneContact(cliente.rut_cliente, cliente.telefono);
                return Ok(consulta);
            }
            return BadRequest();
        }
        [HttpPost("cambiar_correo")]
        public ActionResult ObtenerCambiarCorreo([FromBody] ClienteCorreoDTO cliente)
        {
            if (ModelState.IsValid)
            {
                var consulta = clientesService.ChangeCorreoContact(cliente.rut_cliente, cliente.correo);
                return Ok(consulta);
            }
            return BadRequest();
        }
    }
}
