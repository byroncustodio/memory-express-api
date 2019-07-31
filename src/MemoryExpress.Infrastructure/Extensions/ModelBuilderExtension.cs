using System;
using System.Collections.Generic;
//using MemoryExpress.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace MemoryExpress.Infrastructure
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
	        // modelBuilder.Entity<Image>().HasData(
            //     new Image { Id = 1, Url = "/assets/images/advrtas-cms-thumb.png", Alt = "Advrtas CMS Thumbnail" },
            //     new Image { Id = 2, Url = "/assets/images/memxpress-thumb.png", Alt = "Memory Express Thumbnail" }
            // );
        }
    }
}