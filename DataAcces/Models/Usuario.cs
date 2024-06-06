using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataAcces.Models;

[DataContract(IsReference = true)]
public partial class Usuario
{
    public string Id { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Password { get; set; } = null!;
    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string TipoUsuario { get; set; } = null!;

    public bool? EstaEliminado { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
