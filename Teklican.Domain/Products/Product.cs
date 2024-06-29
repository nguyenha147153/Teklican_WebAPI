using Teklican.Domain.Categories.ValueObjects;
using Teklican.Domain.Models;
using Teklican.Domain.Products.ValueObjects;

namespace Teklican.Domain.Products
{
    public sealed class Product : AggregateRoot<ProductId>
    {
        public string Name { get; private set; } = null!;
        public string? Description { get; private set; }
        public Money Price { get; private set; } = null!;
        public Sku Sku { get; private set; } = null!;
        public string? Status { get; private set; }
        public CategoryId CategoryId { get; private set; } = null!;
        public string? ImagePath {  get; private set; }
        public int Tax {  get; private set; }
        public double OldPrice { get; private set; }
        public Product(
            ProductId ProductId,
            string name,
            string decription,
            Money price,
            Sku sku,
            string status,
            CategoryId categoryId,
            string image,
            int tax,
            double oldPrice) : base(ProductId)
        {
            Name = name;
            Description = decription;
            Price = price;
            Sku = sku;
            Status = status;
            CategoryId = categoryId;
            ImagePath = image;
            Tax = tax;
            OldPrice = oldPrice;
        }

        public static Product Create(
            string name,
            string decription,
            Money price,
            Sku sku,
            string status,
            CategoryId categoryId,
            string image,
            int tax,
            double oldPrice)
        {
            return new(
                ProductId.CreateUnique(),
                name,
                decription,
                price,
                sku,
                status,
                categoryId,
                image,
                tax,
                oldPrice);
        }

        public Product()
        {
        }
    }
}
