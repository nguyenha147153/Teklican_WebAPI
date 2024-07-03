using System.Xml.Linq;
using Teklican.Domain.Abstract;
using Teklican.Domain.Categories;
using Teklican.Domain.Products.ValueObjects;

namespace Teklican.Domain.Products
{
    public class Product : Auditable
    {
        public ProductId Id { get; private set; } = null!;
        public string Name { get; private set; } = null!;
        public string Alias { get; private set; } = null!;
        public string? Description { get; private set; }
        public string Content { get; private set; }
        public Money Price { get; private set; } = null!;
        public decimal? PromotionPrice { get; private set;}
        public Sku Sku { get; private set; } = null!;
        public string? Status { get; private set; }
        public CategoryId CategoryId { get; private set; } = null!;
        public string? Image {  get; private set; }
        public XElement MoreImages { get; private set; }
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
            double oldPrice)
        {
            Id = ProductId;
            Name = name;
            Description = decription;
            Price = price;
            Sku = sku;
            Status = status;
            CategoryId = categoryId;
            Image = image;
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
                new ProductId(Guid.NewGuid()),
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
