using DataAcces.Models;
using Services.DTO.Addres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAddresService
    {
        Task<IEnumerable<Direccion>> GetAddresses(int offset, int limit);
        Task<Direccion> GetById(int id);

        Task<Direccion> Add(CreateAddres param);

        Task<Direccion> Delete(int id);
        Task<Direccion> Update(int id, UpdateAddres param);
    }
}
