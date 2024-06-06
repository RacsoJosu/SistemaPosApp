using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Addres
{
    public class CreateAddres
    {

        [MaxLength(100, ErrorMessage ="La cadena de texto es demaciado larga")]
        [DataType(DataType.Text)]
        public string Calle { get; set; } = null!;
        
        [MaxLength(30, ErrorMessage = "La cadena de texto es demaciado larga")]
        [DataType(DataType.Text)]

        public string Municipio { get; set; } = null!;
        [MaxLength(30, ErrorMessage = "La cadena de texto es demaciado larga")]
        [DataType(DataType.Text)]

        public string Ciudad { get; set; } = null!;

        [MaxLength(1024, ErrorMessage = "La cadena de texto es demaciado larga")]
        [DataType(DataType.MultilineText)]

        public string? Descripcion { get; set; }

        [Range(0, int.MaxValue, ErrorMessage ="El valor debe de ser un numero entero")]
        public int IdCliente { get; set; }


    }
}
