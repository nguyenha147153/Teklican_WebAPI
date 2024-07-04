using Teklican.Domain.Products;

namespace Teklican.Domain.Categories
{
    public sealed class Category 
    {
        public readonly List<Product> _products = new();
        public CategoryId Id { get; private set; } = null!;
        public string Name { get; private set; } = string.Empty;
        public string? Alias { get; private set; }
        public string? Description { get; private set; }
        public int? ParentId { get; private set; }
        public string Image { get; private set; } = string.Empty;
        public IReadOnlyList<Product> Products => _products.ToList();
        public Category(string name)
        {
            Name = name;
        }

        public static Category Create(string name)
        {
            return new(name);
        }

        public void Update(string name)
        {
           Name = name;
        }

        public Category()
        {
        }
    }
}
