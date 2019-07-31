using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MemoryExpress.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MemoryExpress.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>(ConfigureProduct);
        }

        private void ConfigureProduct(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSucces)
        {
            return base.SaveChanges(acceptAllChangesOnSucces);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSucces, CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SaveChangesAsync(acceptAllChangesOnSucces, cancellationToken);
        }
    }
}
