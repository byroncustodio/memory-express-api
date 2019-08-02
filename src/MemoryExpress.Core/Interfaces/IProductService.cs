using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MemoryExpress.Core.Entities;

namespace MemoryExpress.Core.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Product product);
        Task<int> CountProductsAsync();
    }
}