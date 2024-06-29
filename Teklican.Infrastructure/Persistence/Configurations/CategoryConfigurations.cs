using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teklican.Domain.Categories;
using Teklican.Domain.Categories.ValueObjects;

namespace Teklican.Infrastructure.Persistence.Configurations
{
    internal class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            ConfigureCategoriesTable(builder);
        }

        private void ConfigureCategoriesTable(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    c => c.Value,
                    value => CategoryId.Create(value));

            builder.Property(c => c.Name).HasMaxLength(50);
        }
    }
}
