using DataAcces.Models;
using Repository.Interfaces;
using Services.DTO.Product;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
           this._repo = repo;
        }

        public Task<Producto> Add(CreateProduct createProduct)
        {

            if (createProduct.Descripcion == null || createProduct.Descripcion == "")
            {
                createProduct.Descripcion = String.Empty;
                
            }
            var product = new Producto
            {

                Nombre = createProduct.Nombre,
                PrecioUnitario = createProduct.PrecioUnitario,
                CantidadUnidad = createProduct.CantidadUnidad,
                Descripcion = createProduct.Descripcion,
                Medida = createProduct.Medida,
                IdCategoria = createProduct.IdCategoria


            };

            return this._repo.Create(product);
        }

        public async Task<Producto> Delete(int id)
        {
           return await  this._repo.Delete(id);
        }

        public async Task<Producto> GetById(int id)
        {
            return await this._repo.GetById(id);
        }

        public async Task<IEnumerable<Producto>> GetProducts(int offset, int limit)
        {
            var products =  await this._repo.GetAll(offset, limit);
            return products;
        }

        public async Task<Producto> Update(int id, UpdateProduct updateProduct)
        {

            var product = await this._repo.GetById(id);


            if (product == null)
            {
                return null;
                
            }

            if (updateProduct.Nombre != null || updateProduct.Nombre == "" )
            {
                product.Nombre = updateProduct.Nombre;

            }

            if (updateProduct.Descripcion != null || updateProduct.Descripcion == "" )
            {
                product.Descripcion = updateProduct.Descripcion;

                
            }

            if (updateProduct.CantidadUnidad != product.CantidadUnidad)
            {
                product.CantidadUnidad = updateProduct.CantidadUnidad;


            }
            if (updateProduct.PrecioUnitario != product.PrecioUnitario)
            {
                product.PrecioUnitario = updateProduct.PrecioUnitario;


            }
            if (updateProduct.Medida != null )
            {
                product.Medida = updateProduct.Medida;


            }



            return  await this._repo.Update(product);



        }
    }
}
