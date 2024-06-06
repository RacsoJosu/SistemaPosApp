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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SistemaPosDbContext _db;

        public CustomerRepository(SistemaPosDbContext db)
        {
            this._db = db;
        }

        public async Task<Cliente> Create(Cliente customer)
        {
            this._db.Clientes.Add(customer);
            await this._db.SaveChangesAsync();
            return customer;
        }

        public async  Task<Cliente> Delete(int id)
        {
            var customer = await this.GetById(id);

            if (customer == null)
            {
                return null;

            }
            else
            {
                this._db.Clientes.Remove(customer);
                await this._db.SaveChangesAsync();

                return customer;
            }


        }

        public async Task<IEnumerable<Cliente>> GetAll(int offset, int limit )
        {

           
            
            return await this._db.Clientes.Include(p=> p.Pedidos).Skip(offset).Take(limit).ToListAsync();
        }

        public async Task<Cliente> GetByEmail(string email)
        {
            return await this._db.Clientes.FirstOrDefaultAsync( c => c.Email.ToLower().Equals(email));
        }

        public async Task<Cliente> GetById(int id) {
            return await this._db.Clientes.FindAsync(id); 
        }

        public async Task<Cliente> Update( Cliente customer)
        {
            

            this._db.Entry(customer).State = EntityState.Modified;

            try
            {
                await this._db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
                
            }

            return customer;
        }
    }
}
