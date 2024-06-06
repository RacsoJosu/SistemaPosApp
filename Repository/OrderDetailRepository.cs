using DataAcces.Context;
using DataAcces.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly SistemaPosDbContext _db;
        public OrderDetailRepository(SistemaPosDbContext db)
        {
            this._db = db;
        }

        public async Task<IEnumerable<DetallePedido>> Create( IEnumerable<DetallePedido> orderDetailList)
        {
            this._db.DetallePedidos.AddRange(orderDetailList);

            await this._db.SaveChangesAsync();

            return orderDetailList;
            
        }

        public async Task<DetallePedido> CreateOne(DetallePedido item)
        {
            this._db.DetallePedidos.Add(item);
            await this._db.SaveChangesAsync();
            return item;
        }

        public async Task<DetallePedido> Delete(int id)
        {
            var orderDetail = await this.GetById(id);

            if (orderDetail == null)
            {
                return null;

            }
            else
            {
                this._db.DetallePedidos.Remove(orderDetail);
                await this._db.SaveChangesAsync();

                return orderDetail;
            }


        }

        public async Task<IEnumerable<DetallePedido>> GetAll(int offset, int limit)
        {
            return await this._db.DetallePedidos.Include(p => p.Pedido).Include(p=>p.Producto).Skip(offset).Take(limit).ToListAsync();
        }

        public async Task<DetallePedido> GetById(int id)
        {
            return await this._db.DetallePedidos.FindAsync(id);
        }

        public async Task<DetallePedido> Update(DetallePedido orderDetail)
        {

            this._db.Entry(orderDetail).State = EntityState.Modified;

            try
            {
                await this._db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;

            }

            return orderDetail;
        }
    }
}
