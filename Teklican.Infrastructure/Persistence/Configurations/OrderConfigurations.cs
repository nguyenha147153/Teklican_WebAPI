using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teklican.Domain.Orders;
using Teklican.Domain.Orders.ValueObjects;
using Teklican.Domain.Users;

namespace Teklican.Infrastructure.Persistence.Configurations
{
    internal class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            ConfigureOrdersTable(builder);
        }

        private void ConfigureOrdersTable(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    order => order.Value,
                    value => OrderId.Create(value));

            builder.HasOne<Account>()
                .WithMany()
                .HasForeignKey( o => o.AccountId)
                .IsRequired();

            builder.HasMany(o => o.LineItems)
                .WithOne()
                .HasForeignKey(li => li.OrderId);
        }
    }
}
