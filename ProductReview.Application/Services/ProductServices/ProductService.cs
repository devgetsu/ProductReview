using ProductReview.Application.Astractions.RepositoryInterfaces;
using ProductReview.Domain.DTOs;
using ProductReview.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Application.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;

        public ProductService(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<Product> CreateProduct(ProductDTO perDTO)
        {
            var s = await _productRepo.Create(new Product()
            {
                Name = perDTO.Name,
                Description = perDTO.Description,
            });
            return s;
        }

        public async Task<bool> DeleteProductById(int id)
        {
            var x = await _productRepo.Delete(x => x.Id == id);
            return x;
        }

        public async Task<bool> DeleteProductByName(string name)
        {
            var x = await _productRepo.Delete(x => x.Name == name);
            return x;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepo.GetAll();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productRepo.GetByAny(x => x.Id == id);
        }

        public async Task<Product> GetProductByName(string name)
        {
            return await _productRepo.GetByAny(x => x.Name == name);
        }

        public async Task<Product> UpdateProductById(int id, ProductDTO perDTO)
        {
            var s = await _productRepo.GetByAny(x => x.Id == id);
            if (s == null)
            {
                return new Product() { };
            }
            else
            {
                var res = await _productRepo.Update(new Product { Name = perDTO.Name, Description = perDTO.Description});
                return res;
            }
        }

        public async Task<Product> UpdateProductByName(string name, ProductDTO perDTO)
        {
            var s = await _productRepo.GetByAny(x => x.Name == name);
            if (s == null)
            {
                return new Product() { };
            }
            else
            {
                var res = await _productRepo.Update(new Product { Name = perDTO.Name, Description = perDTO.Description});
                return res;
            }
        }
    }
}
