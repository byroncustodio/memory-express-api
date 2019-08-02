using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MemoryExpress.Core.Entities;

namespace MemoryExpress.Infrastructure.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(GetProductSeedData());
        }

        static Product[] GetProductSeedData()
        {
            return new Product[] {
                new Product() { Id = 1, Name = "Test Product 1" },
                new Product() { Id = 2, Name = "Test Product 2" },
                new Product() { Id = 3, Name = "Test Product 3" },
                new Product() { Id = 4, Name = "Test Product 4" }
            };
        }
    }
}