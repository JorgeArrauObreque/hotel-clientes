using System.ComponentModel.DataAnnotations;

namespace hotel_clientes.DTO
{
    public class ClienteTelefonoDTO
    {
        [Required]
        public string rut_cliente {  get; set; }
        [Required]
        [MinLength(8,ErrorMessage = "el largo del telefono debe ser 9")]
        [MaxLength(9, ErrorMessage = "el largo del telefono debe ser 9")]
        public string telefono { get; set; }
    }
}
