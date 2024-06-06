using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataAcces.Models;
[DataContract(IsReference = true)]
public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool? EstaEliminado { get; set; } = false;

    public DateOnly FechaNacimiento { get; set; }

    public string? CodigoPostal { get; set; }

    public string? NumeroTelefono { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Direccion> Direccions { get; set; } = new List<Direccion>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
