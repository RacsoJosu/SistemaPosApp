using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Order
{
    public class UpdateOrder
    {

        [Range(0.0, 1.0, ErrorMessage ="El valor no puede ser mayor a 1.0 ni menor a 0.0")]
        public float Isv { get; set; }

        [Range(0.0, float.MaxValue, ErrorMessage ="El valor debe ser un numero positivo")]
        public float MontoTotal { get; set; }

        [Range(0, int.MaxValue, ErrorMessage ="El valor debe ser numerico y mayor a 0")]
        public int IdDireccion { get; set; }

      
    }
}
