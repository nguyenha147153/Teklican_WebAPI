using Teklican.Domain.Products;
using Teklican.Domain.Products.ValueObjects;

namespace Teklican.Domain.Orders.Entities
{
    public sealed class LineItem
    {
        /* private readonly List<ProductId> _products = new();*/
        public LineItemId Id { get; set; } = null!;
        public OrderId OrderId { get; private set; } = null!;
        public ProductId ProductId { get; private set; } = null!;
        public Money Price { get; private set; } = null!;
        public int Quantity { get; private set; }
        public decimal SubTotal { get; private set; }
        /*public Product Product { get; private set; } = null!;*/

        internal LineItem(
            LineItemId lineItemId,
            OrderId orderId,
            ProductId productId,
            Money price,
            int quantity,
            decimal subTotal)
        {
            Id = lineItemId;
            OrderId = orderId;
            ProductId = productId;
            Price = price;
            Quantity = quantity;
            SubTotal = subTotal;
        }

        public static LineItem Create(
            OrderId orderId,
            ProductId productId,
            Money price,
            int quantity,
            decimal subTotal)
        {
            return new(
                   new LineItemId(Guid.NewGuid()),
                   orderId,
                   productId,
                   price,
                   quantity,
                   subTotal
                );
        }

        private LineItem()
        {

        }
    }
}
