using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MemoryExpress.Core.Entities;

namespace MemoryExpress.Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();

        //Task<Product> GetProductById(int id);
    }
}