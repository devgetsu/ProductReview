using ProductReview.Domain.DTOs;
using ProductReview.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReview.Application.Services.ProductServices
{
    public interface IProductService
    {
        public Task<Product> CreateProduct(ProductDTO perDTO);
        public Task<Product> UpdateProductByName(string name, ProductDTO perDTO);
        public Task<Product> UpdateProductById(int id, ProductDTO perDTO);
        public Task<bool> DeleteProductById(int id);
        public Task<bool> DeleteProductByName(string name);
        public Task<Product> GetProductById(int id);
        public Task<Product> GetProductByName(string name);
        public Task<IEnumerable<Product>> GetAllProducts();
    }
}
