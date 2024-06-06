using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataAcces.Models;

[DataContract(IsReference = true)]
public partial class DetallePedido
{
    public int Id { get; set; }

    public int CantidadProducto { get; set; }

    public float Descuento { get; set; }

    public int IdPedido { get; set; }

    public int IdProducto { get; set; }

    public virtual Pedido Pedido { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
