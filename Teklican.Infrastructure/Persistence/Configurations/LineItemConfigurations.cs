using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teklican.Domain.Orders.Entities;
using Teklican.Domain.Orders.ValueObjects;
using Teklican.Domain.Products;

namespace Teklican.Infrastructure.Persistence.Configurations
{
    internal class LineItemConfigurations : IEntityTypeConfiguration<LineItem>
    {
        public void Configure(EntityTypeBuilder<LineItem> builder)
        {
            ConfigureLineItemsTable(builder);
        }

        private void ConfigureLineItemsTable(EntityTypeBuilder<LineItem> builder)
        {
            builder.ToTable("LineItems");

            builder.HasKey(li =>  li.Id);

            builder.Property(li => li.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    lineItem => lineItem.Value,
                    value => LineItemId.Create(value));

            builder.HasOne<Product>()
                .WithMany()
                .HasForeignKey(li => li.ProductId);

            builder.OwnsOne(li => li.Price);

        }
    }
}
