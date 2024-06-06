using DataAcces.Context;
using DataAcces.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Services.DTO.User;
using Services.Helpers;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;


namespace SistemaPosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Description("Endpoints para el manejo de usuarios")]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings __jwtSettings;
        private readonly SistemaPosDbContext _context;


        public AccountController(JwtSettings jwtSetting, SistemaPosDbContext context)
        {
            __jwtSettings = jwtSetting;
            _context = context;

        }


        [HttpPost]
        [Route("login")]
        [Description("Este enpoint permite a los usuarios a iniciar sesión y genera JWT que nos ayuda en la autenticacione de futuras solicitudes")]
        public IActionResult Login(UserLogin userLogin)
        {
            try
            {
                var token = new JwtToken();
                var searchUser = (from user in _context.Usuarios
                where user.Email == userLogin.Email
                                  select user).FirstOrDefault();




                if (searchUser != null && HandlePassword.verifyPassword(userLogin.Password, searchUser.Password))
                {

                    token = HandlerJwt.GenerateToken(new JwtToken()
                    {
                        Role = searchUser.TipoUsuario,
                        UserName = searchUser.Nombre + " " + searchUser.Apellido,
                        EmailId = searchUser.Email,
                        Id = new Guid(searchUser.Id)
                       


                        

                    }, __jwtSettings);
                }
                else
                {
                    return BadRequest("Contraseña equivocada");
                }

                return Ok(token);

            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el token", ex);
            }

        }
     
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        [Route("[action]")]
        [Description("Muestra la lista de usuarios en base de datos, solo puede ser vista por usuarios Admin")]
        public IActionResult GetUserList()
        {
            var usersList = from user in _context.Usuarios select user;
            return Ok(usersList);
        }


        [HttpPost]
        [Route("signup")]
        [Description("Este enpoint es para el registro de usuarios en el sistema")]

        public async Task<ActionResult<Usuario>> Signup(Signup data)
        {

            if (_context.Usuarios.Any(user => user.Email == data.Email))
            {
                return BadRequest("El email ya existe");
            }

            var user = new Usuario
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = data.Nombre,
                Apellido = data.Apellido,
                Password = HandlePassword.HashPassword(data.Password),
                Email = data.Email,
                FechaNacimiento = data.FechaNacimiento

            };


            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPatch]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        [Route("[action]")]
        [Description("Este enpoint es para realizar el cambio de rol de un usuario en especifico, solo puede ser usado por usaurio Admin")]

        public async Task<ActionResult<Usuario>> ChangeRoleUser( [FromBody] ChangeRoleUser data )
        {

            var user = this._context.Usuarios.FirstOrDefault(user => user.Email == data.Email);
            if (user == null)
            {
                return BadRequest("El usuario no existe");
                
            }

            user.TipoUsuario = data.Role.ToString();

            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpDelete("[action]/{email}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        [Description("Enpoint para eliminar usuarios, solo los Admin pueden eliminar otros usuarios")]

        public async Task<ActionResult<Usuario>> DeleteAccount(string email)
        {

            var user = this._context.Usuarios.FirstOrDefault(user => user.Email == email);
            if (user == null)
            {
                return BadRequest("El usuario no existe");

            }
            _context.Usuarios.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }





    }
}

