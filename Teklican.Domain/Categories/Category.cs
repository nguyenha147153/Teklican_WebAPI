namespace Teklican.Domain.Categories
{
    public sealed class Category 
    {
        public CategoryId Id { get; private set; }
        public string Name { get; private set; } = string.Empty;

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
