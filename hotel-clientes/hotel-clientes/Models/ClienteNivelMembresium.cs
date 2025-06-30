using System;
using System.Collections.Generic;

namespace hotel_clientes.Models;

public partial class ClienteNivelMembresium
{
    public int IdClienteMembresia { get; set; }

    public string DescripcionClienteMembresia { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
