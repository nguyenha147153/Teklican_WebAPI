using Teklican.Domain.Models;
using Teklican.Domain.Orders.ValueObjects;
using Teklican.Domain.Products.ValueObjects;

namespace Teklican.Domain.Orders.Entities
{
    public sealed class OrderDetails : Entity<OrderDetailId>
    {
        private readonly List<ProductId> _products = new();
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
        public string Status { get; set; }
        private IReadOnlyList<ProductId> ProductIds => _products.AsReadOnly();
        
        private OrderDetails(
            OrderDetailId orderDetailId,
            int quantity,
            decimal subTotal,
            string status) : base(orderDetailId)
        {
            Quantity = quantity;
            SubTotal = subTotal;
            Status = status;
        }

        public static OrderDetails Create(
            int quantity,
            decimal subTotal,
            string status)
        {
            return new(
                OrderDetailId.CreateUnique(),
                quantity,
                subTotal,
                status);
        }
    }
}
