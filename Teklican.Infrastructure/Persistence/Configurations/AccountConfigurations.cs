using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teklican.Domain.Roles;
using Teklican.Domain.Users;
using Teklican.Domain.Users.ValueObjects;

namespace Teklican.Infrastructure.Persistence.Configurations
{
    public class AccountConfigurations : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            ConfigureUsersTable(builder);
        }

        private void ConfigureUsersTable(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
               .ValueGeneratedNever()
               .HasConversion(
                   id => id.Value,
                   value => AccountId.Create(value));

            builder.HasOne<Role>()
                .WithMany()
                .HasForeignKey(u => u.RoleId)
                .IsRequired();

            builder.Property(u => u.FirstName).HasMaxLength(50);

            builder.Property(u => u.LastName).HasMaxLength(50);

            builder.Property(u => u.Email).HasMaxLength(100);

            builder.Property(u => u.Password).HasMaxLength(20);

            builder.Property(u => u.Phone).HasMaxLength(10);

            builder.Property(u => u.Address).HasMaxLength(255);

            builder.HasIndex(u => u.Email).IsUnique();
        }
    }
}
