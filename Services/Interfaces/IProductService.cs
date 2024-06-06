using DataAcces.Models;
using Services.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Producto>> GetProducts(int offset, int limit);
        Task<Producto> GetById(int id);

        Task<Producto> Add(CreateProduct param);

        Task<Producto> Delete(int id);
        Task<Producto> Update(int id, UpdateProduct param);
    }
}
