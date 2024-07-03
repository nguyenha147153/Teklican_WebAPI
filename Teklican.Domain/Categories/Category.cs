using Teklican.Domain.Products;

namespace Teklican.Domain.Categories
{
    public sealed class Category 
    {
        public readonly HashSet<Product> _products = new();
        public CategoryId Id { get; private set; } = null!;
        public string Name { get; private set; } = string.Empty;
        public string? Alias { get; private set; }
        public string? Description { get; private set; }
        public int? ParentId { get; private set; }
        public string Image { get; private set; }
        public IReadOnlyList<Product> Products => _products.ToList();
        public Category(CategoryId id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Category Create(CategoryId category, string name)
        {
            return new( category, name);
        }
        public Category()
        {
        }
    }
}
