using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectClean.Domain.Entities;

namespace ProjectClean.Infra.Data.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Description)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Price)
                .HasPrecision(10, 2);

            builder.HasData(
                new Product 
                { 
                    Id = 1, 
                    Name = "Caderno", 
                    Description = "Caderno de 100 folhas", 
                    Price = 7.50M
                },
                new Product 
                { 
                    Id = 2, 
                    Name = "Borracha", 
                    Description = "Borracha branca", 
                    Price = 2.50M
                },
                new Product 
                { 
                    Id = 3, 
                    Name = "Caneta", 
                    Description = "Caneta azul", 
                    Price = 1.50M
                }
            );
        }
    }
}