using DataAcces.Models;
using Repository.Interfaces;
using Services.DTO.Customer;
using Services.DTO.Product;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo)
        {
            this._repo = repo;
        }

        public async Task<Cliente> Add(CreateCustomer createCustomer)
        {
            var customerSearched = await this._repo.GetByEmail(createCustomer.Email);

            if (customerSearched != null)
            {
                return null;
                
            }

            var customer = new Cliente
            {
                Nombre = createCustomer.Nombre,
                Apellido = createCustomer.Apellido,
                Email = createCustomer.Email,
                FechaNacimiento = createCustomer.FechaNacimiento,
                NumeroTelefono = createCustomer.NumeroTelefono,
                CodigoPostal = createCustomer.CodigoPostal

          

            };

            return await this._repo.Create(customer);
        }

        public async Task<Cliente> Delete(int id)
        {
            return await this._repo.Delete(id);
        }

        public async Task<Cliente> GetById(int id)
        {
            return await this._repo.GetById(id);
        }

        public async Task<IEnumerable<Cliente>> GetCustomers(int offset, int limit)
        {
            return await this._repo.GetAll(offset, limit);
        }


        public async Task<Cliente> Update(int id, UpdateCustomer updateCustomer)
        {
            var customer = await this._repo.GetById(id);

            if (customer == null)
            {
                return null;
                
            }


            if (updateCustomer.Nombre != null && !updateCustomer.Nombre.ToLower().Equals(customer.Nombre.ToLower()))
            {
                customer.Nombre = updateCustomer.Nombre;
                
            }

            if (updateCustomer.Apellido != null && !updateCustomer.Apellido.ToLower().Equals(customer.Apellido.ToLower()))
            {
                customer.Apellido = updateCustomer.Apellido;

                
            }

            if (updateCustomer.Email != null && !updateCustomer.Email.ToLower().Equals(customer.Email.ToLower()))
            {
                customer.Email = updateCustomer.Email;


            }

            if (updateCustomer.NumeroTelefono != null && !updateCustomer.NumeroTelefono.Equals(customer.NumeroTelefono))
            {
                customer.NumeroTelefono = updateCustomer.NumeroTelefono;


            }

            if (updateCustomer.FechaNacimiento > DateOnly.FromDateTime(DateTime.Now) )
            {
                return null;


            }

            if (updateCustomer.FechaNacimiento !=  null)
            {
                customer.FechaNacimiento = updateCustomer.FechaNacimiento;

            }

            if (updateCustomer.CodigoPostal != null && updateCustomer.CodigoPostal.ToLower().Equals(customer.CodigoPostal.ToLower()))
            {
                customer.CodigoPostal = updateCustomer.CodigoPostal;


            }

            return await this._repo.Update(customer);




        }
    }
}

