using DataAcces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IAddresRespository : IWriteMethods<Direccion, int>, IReadMethods<Direccion, int>
    {
    }
}
