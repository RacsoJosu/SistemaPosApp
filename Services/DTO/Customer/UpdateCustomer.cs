using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Customer
{
    public class UpdateCustomer
    {
        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

    
        [EmailAddress(ErrorMessage ="Ingresa una dirección de correo valida")]
        public string? Email { get; set; }


        [DataType(DataType.Date, ErrorMessage ="Ingresa una valor tipo fecha")]
        public DateOnly FechaNacimiento { get; set; }

        public string? CodigoPostal { get; set; }

        public string? NumeroTelefono { get; set; }
    }
}
