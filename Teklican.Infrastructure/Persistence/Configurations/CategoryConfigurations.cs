using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teklican.Domain.Categories;

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
                    categoryId => categoryId.Value,
                    value => new CategoryId(value));

            builder.Property(c => c.Name).HasMaxLength(50);
        }
    }
}
