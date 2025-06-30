using hotel_clientes.Models;

namespace hotel_clientes.Servicios
{
    public class ClientesService
    {
        private FacturacionHotelContext _context;
        public ClientesService(FacturacionHotelContext context) 
        { 
            _context = context;
        }
        public Cliente GetCliente(string rut)
        {
            try
            {
                var cliente = _context.Clientes.Where(r => r.RutCliente == rut).FirstOrDefault();
                return cliente;
            }
            catch (Exception e )
            {
                return null;
            }
            
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
                return [];
            }
        }
        public bool DesactivateCliente(string rut_cliente)
        {
            try
            {
                var cliente = _context.Clientes.Where(r => r.RutCliente == rut_cliente).FirstOrDefault();
                if (cliente == null) return false;
                cliente.Estado = 0;
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
        public bool CreateCliente(Cliente cliente)
        {
            try
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool ChangePhoneContact(string rut_cliente,string numero)
        {
            try
            {
                var cliente = GetCliente(rut_cliente);
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
                var cliente = GetCliente(rut_cliente);
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
