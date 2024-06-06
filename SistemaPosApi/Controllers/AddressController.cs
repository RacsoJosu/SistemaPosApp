using DataAcces.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.Addres;
using Services.DTO.Args;
using Services.Interfaces;

namespace SistemaPosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddresService _addressService;

        public AddressController(IAddresService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator, User")]
        [Route("[action]")]
        public async Task<IEnumerable<Direccion>> GetAll([FromQuery] PaginationArgs paginationArgs)
        {

            var addresses  = await this._addressService.GetAddresses(paginationArgs.Offset, paginationArgs.Limit);

            return addresses;

        }

        [HttpGet("[action]/{IdAddres}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator, User")]


        public async Task<IActionResult> GetOne(int IdAddress)
        {

            try
            {



                var addres = await this._addressService.GetById(IdAddress);

                if (addres == null)
                {
                    return NotFound();


                }
                return Ok(addres);


            }
            catch (Exception e)
            {
                    return BadRequest(e.Message);
            }






        }



        [HttpPost]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator, User")]

        public async Task<IActionResult> AddAddres([FromBody] CreateAddres createAddress)
        {



            var address =await this._addressService.Add(createAddress);
            if (address == null)
            {
                return BadRequest("El cliente al que desea asignar la direccion no existe");
                
            }
            return Ok(address);

        }
        [HttpPatch("{IdAddress}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator, User")]

        public async Task<IActionResult> Update(int IdAddress, [FromBody] UpdateAddres updateAddress)
        {
            var address = await this._addressService.Update(IdAddress, updateAddress);
            if (address == null)
            {
                return NotFound();

            }

            

            return Ok("Direccion Actualizada");
        }

        [HttpDelete("{IdAddress}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator, User")]

        public async Task<IActionResult> Delete(int IdAddress)
        {
            var address = await this._addressService.Delete(IdAddress);

            if (address == null)
            {
                return NotFound();

            }
            


            return Ok("Direccion Eliminada");

        }




    }
}
