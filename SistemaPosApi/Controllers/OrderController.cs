using DataAcces.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO.Args;
using Services.DTO.Order;
using Services.DTO.OrderDetail;
using Services.DTO.Product;
using Services.Interfaces;

namespace SistemaPosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator, User")]

        public async Task<IEnumerable<Pedido>> GetAll([FromQuery] PaginationArgs paginationArgs)
        {

            var orders = await this._orderService.GetOrders(paginationArgs.Offset, paginationArgs.Limit);

            return orders;

        }

        [HttpGet("[action]/{IdOrder}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator, User")]


        public async Task<IActionResult> GetOne(int IdOrder)
        {

            var order = await this._orderService.GetById(IdOrder);

            if (order == null)
            {
                return NotFound();

            }





            return Ok(order);

        }



        [HttpPost]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator, User")]

        public async Task<Pedido> AddOrder([FromBody] CreateOrder createOrder)
        {


            return await this._orderService.Add(createOrder);

        }

        [HttpPost]
        [Route("[action]")]
        public async Task<DetallePedido> AddItemOrder([FromBody] ItemAddOrder item)
        {


            return await this._orderService.AdditemOrder(item);

        }




        [HttpPatch("{IdOrder}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator, User")]

        public async Task<IActionResult> Update(int IdOrder, [FromBody] UpdateOrder updateOrder)
        {
            var order = await this._orderService.Update(IdOrder, updateOrder);
            if (order== null)
            {
                return NotFound();

            }




            return Ok("Orden Actualizada");
        }

        [HttpDelete("{IdOrder}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]

        public async Task<IActionResult> Delete(int IdOrder)
        {
            var order = await this._orderService.Delete(IdOrder);

            if (order == null)
            {
                return NotFound();

            }
            


            return Ok("Orden Eliminada");

        }



    }
}
