using Teklican.Domain.Models;
using Teklican.Domain.Orders.ValueObjects;
using Teklican.Domain.Products.ValueObjects;

namespace Teklican.Domain.Orders.Entities
{
    public sealed class LineItem : Entity<LineItemId>
    {
        private LineItem()
        {
        }
        /* private readonly List<ProductId> _products = new();*/
        public OrderId OrderId { get; private set; } = null!;
        public ProductId ProductId { get; private set; } = null!;
        public Money Price { get; private set; } = null!;
        /* public int Quantity { get; private set; }
         public decimal SubTotal { get; private set; }
         public string Status { get; private set; }*/
        /*private IReadOnlyList<ProductId> ProductIds => _products.AsReadOnly();*/

        internal LineItem(
            LineItemId lineItemId,
            OrderId orderId,
            ProductId productId,
            Money price
            /*int quantity,
            decimal subTotal,
            string status*/) : base(lineItemId)
        {
            OrderId = orderId;
            ProductId = productId;
            Price = price;
            /*Quantity = quantity;
            SubTotal = subTotal;
            Status = status;*/
        }
    }
}
