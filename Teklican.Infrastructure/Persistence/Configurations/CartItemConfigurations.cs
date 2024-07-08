using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teklican.Domain.Cart.Entities;
using Teklican.Domain.Products;

namespace Teklican.Infrastructure.Persistence.Configurations
{
    internal class CartItemConfigurations : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            ConfigureCartItemsTable(builder);
        }

        private void ConfigureCartItemsTable(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("CartItem");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    cartItemId => cartItemId.Value,
                    value => new CartItemId(value));

            builder.Property(c => c.ProductId)
               .ValueGeneratedNever()
               .HasConversion(
                   productId => productId.Value,
                   value => new ProductId(value));

            builder.HasOne<Product>()
               .WithMany()
               .HasForeignKey(c => c.ProductId);
        }
    }
}
