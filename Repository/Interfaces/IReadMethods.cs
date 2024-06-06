using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IReadMethods<T, G>
    {
        Task<IEnumerable<T>> GetAll(int offset, int limit);
        Task<T> GetById(G id);
    }
}
