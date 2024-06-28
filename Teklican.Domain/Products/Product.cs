using Teklican.Domain.Category.ValueObjects;
using Teklican.Domain.Models;
using Teklican.Domain.Products.ValueObjects;

namespace Teklican.Domain.Products
{
    public sealed class Product : AggregateRoot<ProductId>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Status { get; set; }
        public CategoryId? CategoryId { get; set; }
        public string? Image {  get; set; }
        public int Tax {  get; set; }
        public double OldPrice { get; set; }
        public Product(
            ProductId ProductId,
            string name,
            string decription,
            decimal price,
            string status,
            CategoryId categoryId,
            string image,
            int tax,
            double oldPrice) : base(ProductId)
        {
            Name = name;
            Description = decription;
            Price = price;
            Status = status;
            CategoryId = categoryId;
            Image = image;
            Tax = tax;
            OldPrice = oldPrice;
        }

        public static Product Create(
            string name,
            string decription,
            decimal price,
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
                status,
                categoryId,
                image,
                tax,
                oldPrice);
        }
    }
}
