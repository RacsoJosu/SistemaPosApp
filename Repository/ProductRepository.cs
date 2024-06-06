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
    public class ProductRepository : IProductRepository
    {
        private readonly SistemaPosDbContext _db;

        public ProductRepository(SistemaPosDbContext db)
        {
            this._db = db;
        }

        public async Task<Producto> Create(Producto product)
        {
            this._db.Productos.Add(product);
            await this._db.SaveChangesAsync();
            return product;
        }

        public async  Task<Producto> Delete(int id)
        {
            var product = await this.GetById(id);

            if (product == null)
            {
                return null;

            }
            else
            {
                this._db.Productos.Remove(product);
                await this._db.SaveChangesAsync();

                return product;
            }


        }

        public async Task<IEnumerable<Producto>> GetAll(int offset, int limit )
        {

            //var query = from product in this._db.Productos
              //          join categorie in this._db.Categorias
                //        on product.IdCategoria equals categorie.Id
                  //      select product;
            
            return await this._db.Productos.Include(p=> p.Categoria).Skip(offset).Take(limit).ToListAsync();
        }

        public async Task<Producto> GetById(int id) {
            return await this._db.Productos.FindAsync(id); 
        }

        public async Task<Producto> Update( Producto product)
        {
            

            this._db.Entry(product).State = EntityState.Modified;

            try
            {
                await this._db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
                
            }

            return product;
        }
    }
}
