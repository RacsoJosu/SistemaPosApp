using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IWriteMethods<T, G>
    {
        Task<T> Create(T param);

        Task<T> Delete(G id);
        Task<T> Update(T param);

    }
}
