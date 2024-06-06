using DataAcces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ICustomerRepository : IWriteMethods<Cliente, int>, IReadMethods<Cliente, int>
    {
        Task<Cliente> GetByEmail(string email);

    }
}
