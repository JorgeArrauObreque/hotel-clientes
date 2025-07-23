using System;
using System.Collections.Generic;

namespace hotel_clientes.Models;

public partial class ClienteEstado
{
    public int IdClienteEstado { get; set; }

    public string DescripcionClienteEstado { get; set; } = null!;

    public DateTime FechaIngreso { get; set; }

    public DateTime FechaActualizacion { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
