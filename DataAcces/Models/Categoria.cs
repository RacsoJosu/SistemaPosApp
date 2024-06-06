using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataAcces.Models;

[DataContract(IsReference = true)]
public partial class Categoria
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool? EstaEliminado { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
