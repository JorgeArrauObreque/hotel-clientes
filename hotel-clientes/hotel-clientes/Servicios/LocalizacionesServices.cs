using hotel_clientes.Models;

namespace hotel_clientes.Servicios
{
    public class LocalizacionesServices
    {
        private FacturacionHotelContext _context;
        public LocalizacionesServices(FacturacionHotelContext context) {
            this._context = context;
        }
        public object[] GetComunasCiudad(int ciudad)
        {
            var comuna = _context.Comunas.Where(r => r.IdCiudad == ciudad).Select(r=> new {id = r.IdComuna, nombre_comuna = r.IdCiudad}).ToArray();
            return comuna;  
        }
        public object[] GetCiudades()
        {
            var ciudades = _context.Ciudads.Select(r => new { id = r.IdCiudad, nombre_ciudad = r.NombreCiudad }).ToArray();
            return ciudades;
        }
    }
}
