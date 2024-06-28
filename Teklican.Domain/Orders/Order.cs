using Teklican.Domain.Customer.ValueObjects;
using Teklican.Domain.Models;
using Teklican.Domain.Orders.Entities;
using Teklican.Domain.Orders.ValueObjects;

namespace Teklican.Domain.Orders
{
    public sealed class Order : AggregateRoot<OrderId>
    {
        private readonly List<OrderDetails> _orderDetails = new();

        public CustomerId CustomerId { get; set; }  
        public decimal Total { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status {get; set; }
        public IReadOnlyList<OrderDetails> Details => _orderDetails.AsReadOnly();
        public Order(
            OrderId orderId,
            CustomerId customerId,
            decimal total,
            DateTime createdDate,
            string status) : base(orderId)
        {
            CustomerId = customerId;
            Total = total;
            CreatedDate = createdDate;
            Status = status;
        }

        public static Order Create(
            CustomerId customerId,
            decimal total,
            DateTime createdDate,
            string status)
        {
            return new(
                OrderId.CreateUnique(),
                customerId,
                total,
                createdDate,
                status);
        }
    }
}
