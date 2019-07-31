using System.Collections.Generic;
using System.Threading.Tasks;
using MemoryExpress.Core.Entities;
using MemoryExpress.Core.Interfaces;

namespace MemoryExpress.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IAsyncRepository<Product> _productRepository;

        public ProductService(IAsyncRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();

            return products;
            // return _appContext.Projects
            //     .Include(pi => pi.Images).ThenInclude(i => i.Image)
            //     .Include(pt => pt.Technologies).ThenInclude(t => t.Technology)
            //     .OrderByDescending(x => x.DateStarted)
            //     .ToList();
        }

        // public Project GetProjectById(int id)
        // {
        //     return _appContext.Projects
        //         .Where(p => p.Id == id)
        //         .Include(pt => pt.Technologies).ThenInclude(t => t.Technology)
        //         .SingleOrDefault();
        // }
    }
}