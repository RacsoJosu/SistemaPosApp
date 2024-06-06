using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataAcces.Models;

[DataContract(IsReference = true)]
public partial class Direccion
{
    public int Id { get; set; }

    public string Calle { get; set; } = null!;

    public string Municipio { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int IdCliente { get; set; }

    public bool? EstaEliminado { get; set; } = false;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
