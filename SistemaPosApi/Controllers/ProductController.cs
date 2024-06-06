using DataAcces.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using Services.DTO.Args;
using Services.DTO.Product;
using Services.Interfaces;


namespace SistemaPosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            this._productService = productService;

        }
        [HttpGet]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator, User")]

        public async Task<IEnumerable<Producto>> GetAll([FromQuery] PaginationArgs paginationArgs)
        {
          
            var products = await this._productService.GetProducts(paginationArgs.Offset, paginationArgs.Limit);

            return products;

        }

        [HttpGet("{IdProduct}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator, User")]


        public async Task<IActionResult> GetOne(int IdProduct)
        {

            var product = await this._productService.GetById(IdProduct);

            if (product == null)
            {
                return NotFound();
                
            }

            



            return Ok(product);

        }



        [HttpPost]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator, User")]

        public async Task<Producto> AddProduct([FromBody] CreateProduct createProduct)
        {
            

            return await this._productService.Add(createProduct);

        }
        [HttpPatch("{IdProduct}")]
        public async Task<IActionResult> Update( int IdProduct , [FromBody]  UpdateProduct updateProduct)
        {
            var product = await this._productService.Update(IdProduct, updateProduct);
            if (product == null)
            {
                return NotFound();
                
            }

            //var jsonResponse = JsonConvert.SerializeObject(new {MSJ="Producto Actualizado", Data=product});



            return Ok("Producto Actualizado");
        }

        [HttpDelete("{IdProduct}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]

        public async Task<IActionResult> Delete(int IdProduct)
        {
            var product = await this._productService.Delete(IdProduct);

            if (product == null)
            {
                return NotFound();
                
            }
            //var jsonResponse = JsonConvert.SerializeObject(new { MSJ = "Producto Eliminado", Data = product });



            return Ok("Producto Eliminado");

        }
    }
}
