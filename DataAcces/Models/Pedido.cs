using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataAcces.Models;


[DataContract(IsReference = true)]
public partial class Pedido
{
    public int Id { get; set; }

    public DateTime? FechaPedido { get; set; }

    public bool? Estado { get; set; } = false;

    public float Isv { get; set; }

    public float MontoTotal { get; set; }

    public string IdUsuario { get; set; } = null!;

    public int IdCliente { get; set; }

    public int IdDireccion { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Direccion Direccion { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
