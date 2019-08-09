using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemoryExpress.Core.Entities;
using MemoryExpress.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MemoryExpress.Infrastructure.Data
{
    public class ProductRepository : EfRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) 
        { 
        }

        public async Task<Product> FindProductById(int id)
        {
            var product = await _context.Products
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            return product;
        }

        public async Task<IEnumerable<Product>> FindProductsByName(string name)
        {
            var products = await _context.Products
                .Where(p => p.Name == name)
                .ToListAsync();

            return products;
        }
    }
}