using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.OrderDetail
{
    public class CreateOrderDetail
    {
        [Range(0, int.MaxValue, ErrorMessage ="El valor debe ser mayor a 0")]
        public int CantidadProducto { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "El valor debe ser mayor a 0")]
        public float Descuento { get; set; }

        [Range(1000, int.MaxValue, ErrorMessage ="El valor debe ser mayor a 1000")]
        public int IdProducto { get; set; }
    }
}
