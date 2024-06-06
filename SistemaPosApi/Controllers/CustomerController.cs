using DataAcces.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.Args;
using Services.DTO.Customer;
using Services.Interfaces;

namespace SistemaPosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
            
        {

            this._customerService = customerService;
        }


        [HttpGet]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator, User")]

        public async Task<IEnumerable<Cliente>> GetAll([FromQuery] PaginationArgs paginationArgs)
        {

            var customers = await this._customerService.GetCustomers(paginationArgs.Offset, paginationArgs.Limit);

            return customers;

        }

        [HttpGet("[action]/{IdCustomer}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator, User")]

        public async Task<IActionResult> GetOne(int IdCustomer)
        {

            var customer = await this._customerService.GetById(IdCustomer);

            if (customer == null)
            {
                return NotFound();

            }





            return Ok(customer);

        }



        [HttpPost]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator, User")]

        public async Task<IActionResult> AddCustomer([FromBody] CreateCustomer createCustomer)
        {


            var customer = await this._customerService.Add(createCustomer);
            if (customer == null)
            {
                return BadRequest("El Correo ya existe");
                
            }
            return Ok(customer);

        }
        [HttpPatch("{IdCustomer}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator, User")]

        public async Task<IActionResult> Update(int IdCustomer, [FromBody] UpdateCustomer updateCustomer)
        {
            var customer = await this._customerService.Update(IdCustomer, updateCustomer);
            if (customer == null)
            {
                return NotFound();

            }


            return Ok("Cliente Actualizado");
        }

        [HttpDelete("{IdCustomer}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]

        public async Task<IActionResult> Delete(int IdCustomer)
        {
            var product = await this._customerService.Delete(IdCustomer);

            if (product == null)
            {
                return NotFound();

            }
           



            return Ok("Cliente Eliminado");

        }




    }
}
