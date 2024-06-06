using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.User
{
    public class ChangeRoleUser
    {
        [Required(ErrorMessage ="Por favor introduzca un correo electronico")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage ="Por favor introduzca un rol [Admin, User]")]
        public Roles Role { get; set; } 
    }
}

