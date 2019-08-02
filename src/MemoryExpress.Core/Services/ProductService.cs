using System.Collections.Generic;
using System.Threading.Tasks;
using MemoryExpress.Core.Entities;
using MemoryExpress.Core.Interfaces;

namespace MemoryExpress.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly ILoggerAdapter<ProductService> _logger;

        public ProductService(IAsyncRepository<Product> productRepository, ILoggerAdapter<ProductService> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetAsync(id);

            if (product == null)
            {
                _logger.LogInformation($"No product found with Id {id}");
            }

            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();

            return products;
        }

        public async Task AddProductAsync(Product product)
        {
            // Validate product
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            // Validate product
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(Product product)
        {
            // Validate product
            await _productRepository.DeleteAsync(product);
        }

        public async Task<int> CountProductsAsync()
        {
            var count = await _productRepository.CountAsync();

            return count;
        }
    }
}