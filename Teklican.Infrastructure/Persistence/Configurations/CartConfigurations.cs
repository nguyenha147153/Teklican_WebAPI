using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teklican.Domain.Accounts;
using Teklican.Domain.Carts;

namespace Teklican.Infrastructure.Persistence.Configurations
{
    internal class CartConfigurations : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            ConfigureCartsTable(builder);
        }

        private void ConfigureCartsTable(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart");

            builder.HasKey(c=>c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    cartId => cartId.Value,
                    value => new CartId(value));

            builder.Property(u => u.AccountId)
               .ValueGeneratedNever()
               .HasConversion(
                   accountId => accountId.Value,
                   value => new AccountId(value));

            builder.HasMany(o => o.CartItems)
               .WithOne()
               .HasForeignKey(li => li.CartId);
        }
    }
}
