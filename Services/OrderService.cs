using DataAcces.Models;
using Repository.Interfaces;
using Services.DTO.Order;
using Services.DTO.OrderDetail;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;
        private readonly IOrderDetailRepository _detailRepository;

        public OrderService (IOrderRepository repo, IOrderDetailRepository detailRepository)
        {
            _repo = repo;
            _detailRepository = detailRepository;
        }
    

        public async Task<Pedido> Add(CreateOrder createdOrder)
        {

           
            var order = new Pedido
            {
                Isv = createdOrder.Isv,
                MontoTotal = createdOrder.MontoTotal,
                IdDireccion = createdOrder.IdDireccion,
                IdCliente = createdOrder.IdCliente,
                IdUsuario = createdOrder.IdUsuario,

            };
            var currentOrder = await this._repo.Create(order);

            foreach (var item in createdOrder.listOrderDetails)
            {
                var itemTem = new DetallePedido
                {
                    
                    CantidadProducto = createdOrder.listOrderDetails.Count(),
                    Descuento = item.Descuento,
                    IdPedido = currentOrder.Id,
                    IdProducto = item.IdProducto
                };

                currentOrder.DetallePedidos.Add(itemTem);   





            }

            var listItems = await this._detailRepository.Create(currentOrder.DetallePedidos);

            currentOrder.DetallePedidos = listItems.ToList();


            return currentOrder;





           



            
            
            
            
        }

        public async Task<DetallePedido> AdditemOrder(ItemAddOrder item)
        {
            var itemTem = new DetallePedido
            {

                CantidadProducto = item.CantidadProducto,
                Descuento = item.Descuento,
                IdPedido = item.IdOrder,
                IdProducto = item.IdProducto
            };

            return await this._detailRepository.CreateOne(itemTem);
        }

        public Task<IEnumerable<DetallePedido>> AddOrderDetail(List<DetallePedido> orderDetailList)
        {
            throw new NotImplementedException();
        }

        public async Task<Pedido> Delete(int id)
        {
            return await this._repo.Delete(id);
        }

        public async Task<Pedido> GetById(int id)
        {
            return await this._repo.GetById(id);
        }

        public async Task<IEnumerable<Pedido>> GetOrders(int offset, int limit)
        {
            return await this._repo.GetAll(offset, limit);
        }

        public async Task<Pedido> Update(int id, UpdateOrder updatedOrder)
        {
            var order = await this._repo.GetById(id);

            if (order == null)
            {
                return null;
                
            }

            if (updatedOrder.Isv == 0.0 || updatedOrder.Isv == null)
            {
                order.Isv = updatedOrder.Isv;
                
            }
            if (updatedOrder.MontoTotal == 0.0 || updatedOrder.MontoTotal == null)
            {
                order.MontoTotal = updatedOrder.MontoTotal;

            }
            if (updatedOrder.IdDireccion != order.IdDireccion || updatedOrder.IdDireccion == null)
            {
                order.Isv = updatedOrder.Isv;

            }

            return await this._repo.Update(order);

        }
    }
    }

