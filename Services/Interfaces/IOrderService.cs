using DataAcces.Models;
using Services.DTO.Order;
using Services.DTO.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Pedido>> GetOrders(int offset, int limit);
        Task<Pedido> GetById(int id);

        Task<Pedido> Add(CreateOrder param);

        Task<Pedido> Delete(int id);
        Task<Pedido> Update(int id, UpdateOrder param);

        Task<IEnumerable<DetallePedido>> AddOrderDetail(List<DetallePedido> orderDetailList);
        Task<DetallePedido> AdditemOrder(ItemAddOrder item);
    }
}
