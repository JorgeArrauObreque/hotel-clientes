using System.ComponentModel.DataAnnotations;

namespace hotel_clientes.DTO
{
    public class ClienteCorreoDTO
    {
        [Required(ErrorMessage = "se requiere el rut del cliente")]
        public string rut_cliente { get; set; }
        [Required(ErrorMessage ="el correo es requerido")]
        [EmailAddress(ErrorMessage ="el formato no es correcto")]
        public string correo { get; set; }
    }
}
