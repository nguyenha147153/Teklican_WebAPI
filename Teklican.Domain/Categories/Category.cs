using Teklican.Domain.Categories.ValueObjects;
using Teklican.Domain.Models;

namespace Teklican.Domain.Categories
{
    public sealed class Category : Entity<CategoryId>
    {
        public Category()
        {
        }
        public string Name { get; private set; } = null!;

        public Category(CategoryId categoryId, string name) : base(categoryId)
        {
            Name = name;
        }

        public static Category Create(string name)
        {
            return new(CategoryId.CreateUnique(), name);
        }
    }
}
