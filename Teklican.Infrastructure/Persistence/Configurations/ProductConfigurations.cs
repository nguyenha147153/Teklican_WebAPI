using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teklican.Domain.Categories;
using Teklican.Domain.Products;
using Teklican.Domain.Products.ValueObjects;

namespace Teklican.Infrastructure.Persistence.Configurations
{
    internal class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            ConfigureProductsTable(builder);
        }

        private void ConfigureProductsTable(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    productId => productId.Value,
                    value => new ProductId(value));

            builder.Property(p => p.CategoryId)
                .HasConversion(
                    categoryId => categoryId.Value,
                    value => new CategoryId(value));

            /*builder.HasOne<Category>()
               .WithMany()
               .HasForeignKey(c => c.CategoryId)
               .IsRequired();*/

            builder.Property(p => p.Sku)
                .HasConversion(
                    sku => sku.Value,
                    value => Sku.Create(value)!);

            builder.OwnsOne(p => p.Price, priceBuilder =>
            {
                priceBuilder.Property(m => m.Currency).HasMaxLength(3);
            });

            builder.Property(p => p.Name).HasMaxLength(50);

            builder.Property(p => p.Description).HasMaxLength(150);

            builder.Property(p => p.Status).HasMaxLength(20);

        }
    }
}
