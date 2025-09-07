using hotel_clientes.DTO;
using hotel_clientes.Models;
using Microsoft.EntityFrameworkCore;

namespace hotel_clientes.Servicios
{
    public class ClientesService
    {
        private HotelClientesContext _context;
        public ClientesService(HotelClientesContext context) 
        { 
            _context = context;
        }
        public object GetCliente(string rut)
        {

            var cliente = _context.Clientes.Where(r => r.RutCliente == rut)
                .Include(r=>r.IdEstadoNavigation)
                .Include(r=>r.IdNivelMembresiaNavigation)
                .Include(r=>r.IdComunaNavigation)
                .Include(r=>r.IdComunaNavigation.IdCiudadNavigation)
                .Select(r=>new {rut = r.RutCliente, nombre_completo = string.Concat(r.Nombres," ",r.Apellidos),
                        direccion = r.Direccion, 
                        comuna = new {  nombre_comuna = r.IdComunaNavigation.NombreComuna, 
                        region = new { nombre_ciudad = r.IdComunaNavigation.IdCiudadNavigation.NombreCiudad } },
                        correo = r.Correo,telefono = r.Telefono, membresia = r.IdNivelMembresiaNavigation.DescripcionClienteMembresia,
                        estado = r.IdEstadoNavigation.DescripcionClienteEstado})
                .FirstOrDefault();
            return cliente;
      

        }
        public Cliente[] GetClientes()
        {
            try
            {
                var clientes = _context.Clientes.ToArray();
                return clientes;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool DesactivateCliente(string rut_cliente)
        {
            try
            {
                var cliente = _context.Clientes.Where(r => r.RutCliente == rut_cliente).FirstOrDefault();
                if (cliente == null) return false;
                cliente.IdEstado = 0;
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        //comentado por la eficiencia de el getCliente() dependiendo de su valor null o no
        //public bool ExistsCliente(string rut_cliente)
        //{
        //    try
        //    {
        //        var consulta = _context.Clientes.Where(r => r.RutCliente == rut_cliente).FirstOrDefault();
        //        return consulta == null ? false : true;
        //    }
        //    catch (Exception e )
        //    {
        //        return false;
        //    }
        //}
        public bool CreateCliente(ClienteCrearDTO cliente)
        {
            try
            {
                Cliente cliente_nuevo = new Cliente();
                cliente_nuevo.Telefono = cliente.Telefono;
                cliente_nuevo.RutCliente = cliente.RutCliente;
                cliente_nuevo.Correo = cliente.Correo;
                cliente_nuevo.ClienteFrecuente = false;
                cliente_nuevo.Apellidos = cliente.Apellidos;
                cliente_nuevo.Nombres = cliente.Nombres;
                cliente_nuevo.Direccion = cliente.Direccion;
                cliente_nuevo.Genero = cliente.Genero;
                cliente_nuevo.IdComuna = cliente.IdComuna;
                cliente_nuevo.PaisOrigen = cliente.PaisOrigen;
                cliente_nuevo.Observaciones = cliente.Observaciones;
                cliente_nuevo.Nacionalidad = cliente.Nacionalidad;
                cliente_nuevo.FechaActualizacion = DateTime.Now;
                cliente_nuevo.FechaCreacion = DateTime.Now;
                cliente_nuevo.IdEstado = 1;
                cliente_nuevo.Creadopor = "Admin";
                cliente_nuevo.Modificadopor = "Admin";
                _context.Clientes.Add(cliente_nuevo);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        private Cliente getClienteObjeto(string rut)
        {
            return _context.Clientes.Where(r=>r.RutCliente == rut).FirstOrDefault();
        }
        public bool ChangePhoneContact(string rut_cliente,string numero)
        {
            try
            {
                var cliente = getClienteObjeto(rut_cliente);
                if (cliente == null) return false;
                cliente.Telefono = numero;
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool ChangeCorreoContact(string rut_cliente, string correo)
        {
            try
            {
                var cliente = getClienteObjeto(rut_cliente);
                if (cliente == null) return false;
                cliente.Correo = correo;
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
