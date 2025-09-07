using System;
using System.Collections.Generic;

namespace hotel_clientes.Models;

public partial class Comuna
{
    public int IdComuna { get; set; }

    public string NombreComuna { get; set; } = null!;

    public int IdCiudad { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual Ciudad IdCiudadNavigation { get; set; } = null!;
}
