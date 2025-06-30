using System;
using System.Collections.Generic;

namespace hotel_clientes.Models;

public partial class Cliente
{
    public string RutCliente { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public DateTime FechaActualizacion { get; set; }

    public int Estado { get; set; }

    public int IdComuna { get; set; }

    public string Direccion { get; set; } = null!;

    public string Nacionalidad { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public string PaisOrigen { get; set; } = null!;

    public string? Observaciones { get; set; }

    public bool ClienteFrecuente { get; set; }

    public string Creadopor { get; set; } = null!;

    public string Modificadopor { get; set; } = null!;

    public int? IdNivelMembresia { get; set; }

    public virtual Comuna IdComunaNavigation { get; set; } = null!;

    public virtual ClienteNivelMembresium? IdNivelMembresiaNavigation { get; set; }
}
