using hotel_clientes.Models;
using Microsoft.EntityFrameworkCore;
namespace hotel_clientes.Servicios
{
    public class LocalizacionesServices
    {
        private HotelClientesContext _context;
        public LocalizacionesServices(HotelClientesContext context) {
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
        public object[] GetCiudadesComunas()
        {
            var ciudades = _context.Ciudads.Include(r=>r.Comunas).Select(r => new { id = r.IdCiudad, nombre_ciudad = r.NombreCiudad,comunas = r.Comunas.Select(c=>new {id = c.IdComuna,nombre_comuna = c.NombreComuna}) }).ToArray();
            return ciudades;
        }
    }
}
