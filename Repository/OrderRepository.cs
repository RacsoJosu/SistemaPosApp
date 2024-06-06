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
    public class OrderRepository : IOrderRepository
    {
        private readonly SistemaPosDbContext _db;

        public OrderRepository(SistemaPosDbContext db)
        {
            this._db = db;
        }

        public async Task<Pedido> Create(Pedido order)
        {
            this._db.Pedidos.Add(order);
            await this._db.SaveChangesAsync();
            return order;
        }

        public async  Task<Pedido> Delete(int id)
        {
            var order = await this.GetById(id);

            if (order == null)
            {
                return null;

            }
            else
            {
                this._db.Pedidos.Remove(order);
                await this._db.SaveChangesAsync();

                return order;
            }


        }

        public async Task<IEnumerable<Pedido>> GetAll(int offset, int limit )
        {

           
            
            return await this._db.Pedidos.Include(p=> p.Cliente).Skip(offset).Take(limit).ToListAsync();
        }

        public async Task<Pedido> GetById(int id) {
            return await this._db.Pedidos.FindAsync(id); 
        }

        public async Task<Pedido> Update( Pedido order)
        {
            

            this._db.Entry(order).State = EntityState.Modified;

            try
            {
                await this._db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
                
            }

            return order;
        }
    }
}
