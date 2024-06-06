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
    public class AddresRepository : IAddresRespository
    {
        private readonly SistemaPosDbContext _db;

        public AddresRepository(SistemaPosDbContext db)
        {
            this._db = db;
        }

        public async Task<Direccion> Create(Direccion addres)
        {
            this._db.Direccions.Add(addres);
            await this._db.SaveChangesAsync();
            return addres;
        }

        public async  Task<Direccion> Delete(int id)
        {
            var addres = await this.GetById(id);

            if (addres == null)
            {
                return null;

            }
            else
            {
                this._db.Direccions.Remove(addres);
                await this._db.SaveChangesAsync();

                return addres;
            }


        }

        public async Task<IEnumerable<Direccion>> GetAll(int offset, int limit )
        {

          
            
            return await this._db.Direccions.Include(p=> p.Cliente).Skip(offset).Take(limit).ToListAsync();
        }

        public async Task<Direccion> GetById(int id) {
            return await this._db.Direccions.FindAsync(id); 
        }

        public async Task<Direccion> Update( Direccion addres)
        {
            

            this._db.Entry(addres).State = EntityState.Modified;

            try
            {
                await this._db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
                
            }

            return addres;
        }
    }
}
