using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemoryExpress.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MemoryExpress.Infrastructure.Data
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext context, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                await context.Database.MigrateAsync();

                if (!context.Products.Any())
                {
                    context.Products.AddRange(GetPreconfiguredProducts());

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    await SeedAsync(context, retryForAvailability);
                }
            }
        }

        static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product() { Name = "Test Product 1" },
                new Product() { Name = "Test Product 2" },
                new Product() { Name = "Test Product 3" }
            };
        }
    }
}