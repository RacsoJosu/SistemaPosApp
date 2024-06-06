using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Product
{
    public class CreateProduct
    {
        [Required]
        public string Nombre { get; set; } = null!;


        public string? Descripcion { get; set; }
        [Required]
        public float PrecioUnitario { get; set; }

        [Required]
        public float CantidadUnidad { get; set; }

        [Required]
        public string Medida { get; set; } = null!;
        [Required]
        public int IdCategoria { get; set; }
    }
}
