using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MemoryExpress.Core.Entities;

namespace MemoryExpress.Core.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> FindProductById(int id);

        Task<IEnumerable<Product>> FindProductsByName(string name);
    }
}