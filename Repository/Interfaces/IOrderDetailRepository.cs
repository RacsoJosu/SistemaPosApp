using DataAcces.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IOrderDetailRepository : IReadMethods<DetallePedido, int>
    {
        Task<IEnumerable<DetallePedido>> Create(IEnumerable<DetallePedido> param);

        Task<DetallePedido> CreateOne(DetallePedido param);

        Task<DetallePedido> Delete(int id);
        Task<DetallePedido> Update(DetallePedido param);



    }
}
