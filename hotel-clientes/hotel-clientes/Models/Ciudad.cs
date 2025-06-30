using System;
using System.Collections.Generic;

namespace hotel_clientes.Models;

public partial class Ciudad
{
    public int IdCiudad { get; set; }

    public string NombreCiudad { get; set; } = null!;

    public virtual ICollection<Comuna> Comunas { get; set; } = new List<Comuna>();
}
