using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Customer
{
    public class CreateCustomer
    {
        [Required(ErrorMessage ="El nombre es obligatorio")]
        public string Nombre { get; set; } = null!;
        
        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string Apellido { get; set; } = null!;

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage ="Ingresa un Correo valido")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date, ErrorMessage = "Ingresa una valor tipo fecha")]
        public DateOnly FechaNacimiento { get; set; }

        public string? CodigoPostal { get; set; } = String.Empty;

        public string? NumeroTelefono { get; set; } = String.Empty;
    }
}
