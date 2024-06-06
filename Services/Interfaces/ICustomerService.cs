using DataAcces.Models;
using Services.DTO.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Cliente>> GetCustomers(int offset, int limit);
        Task<Cliente> GetById(int id);

        Task<Cliente> Add(CreateCustomer param);

        Task<Cliente> Delete(int id);
        Task<Cliente> Update(int id, UpdateCustomer param);
    }
}

