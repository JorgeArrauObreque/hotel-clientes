using hotel_clientes.Models;

namespace hotel_clientes.DTO
{
    public class ClienteCrearDTO
    {
        public string RutCliente { get; set; } = null!;

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public int Estado { get; set; }

        public int IdComuna { get; set; }

        public string Direccion { get; set; } = null!;

        public string Nacionalidad { get; set; } = null!;

        public string Genero { get; set; } = null!;

        public string PaisOrigen { get; set; } = null!;

        public string? Observaciones { get; set; }
        public int? IdNivelMembresia { get; set; }

    }
}
