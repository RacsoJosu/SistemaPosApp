using DataAcces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IOrderRepository : IWriteMethods<Pedido, int>, IReadMethods<Pedido, int>
    {
    }
}
