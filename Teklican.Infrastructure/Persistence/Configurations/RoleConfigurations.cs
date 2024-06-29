using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teklican.Domain.Roles;
using Teklican.Domain.Roles.ValueObjects;

namespace Teklican.Infrastructure.Persistence.Configurations
{
    internal class RoleConfigurations : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            ConfigureRolesTable(builder);
        }

        private void ConfigureRolesTable(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    r => r.Value,
                    value => RoleId.Create(value));

            builder.Property(r => r.Name).HasMaxLength(20);
        }
    }
}
