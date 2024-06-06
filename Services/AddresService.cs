using DataAcces.Models;
using Repository.Interfaces;
using Services.DTO.Addres;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AddresService : IAddresService
    {
        private readonly IAddresRespository _repo;
        private readonly ICustomerRepository _customerRepository;

        public AddresService(IAddresRespository repo, ICustomerRepository customerRepository)
        {
            _repo = repo;
            _customerRepository = customerRepository;
        }

        public async Task<Direccion> Add(CreateAddres createdAddres)
        {
            var customer = await this._customerRepository.GetById(createdAddres.IdCliente);

            if (customer == null)
            {
                return null;
                
            }

            var address = new Direccion
            {
                Calle = createdAddres.Calle,
                Ciudad = createdAddres.Ciudad,
                Municipio = createdAddres.Municipio,
                Descripcion = createdAddres.Descripcion,
                IdCliente = createdAddres.IdCliente
                
            };

            return await this._repo.Create(address);
            
        }

        public async Task<Direccion> Delete(int id)
        {
            return await this._repo.Delete(id);
        }

        public async Task<IEnumerable<Direccion>> GetAddresses(int offset, int limit)
        {
            return await this._repo.GetAll(offset, limit);
        }

        public async Task<Direccion> GetById(int id)
        {
            return  await this._repo.GetById(id);
        }

        public async Task<Direccion> Update(int id, UpdateAddres updateAddres)
        {
            var addres = await this._repo.GetById(id);
            if (addres == null)
            {
                return null;
            }

            if (updateAddres.Calle != null && updateAddres.Calle.ToLower().Equals(addres.Calle.ToLower()))
            {
                addres.Calle = updateAddres.Calle;
                
            }
            if (updateAddres.Municipio != null && updateAddres.Municipio.ToLower().Equals(addres.Municipio.ToLower()))
            {
                addres.Municipio = updateAddres.Municipio;

            }
            if (updateAddres.Ciudad != null && updateAddres.Ciudad.ToLower().Equals(addres.Ciudad.ToLower()))
            {
                addres.Ciudad = updateAddres.Ciudad;

            }
            if (updateAddres.Descripcion != null && updateAddres.Descripcion.ToLower().Equals(addres.Descripcion.ToLower()))
            {
                addres.Descripcion = updateAddres.Descripcion;

            }

            return await this._repo.Update(addres);
           
        }
    }
}
