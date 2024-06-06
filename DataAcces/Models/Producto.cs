using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataAcces.Models;


[DataContract(IsReference = true)]
public partial class Producto
{

    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public float PrecioUnitario { get; set; }

    public float CantidadUnidad { get; set; }

    public string Medida { get; set; } = null!;

    public int IdCategoria { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

    public DateTime? DeletedAt { get; set; } = DateTime.Now;

    public bool? IsDeleted { get; set; } = false;

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual Categoria Categoria { get; set; } = null!;
}
