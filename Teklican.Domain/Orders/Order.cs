using Teklican.Domain.Models;
using Teklican.Domain.Orders.Entities;
using Teklican.Domain.Orders.ValueObjects;
using Teklican.Domain.Products;
using Teklican.Domain.Users;
using Teklican.Domain.Users.ValueObjects;

namespace Teklican.Domain.Orders
{
    public sealed class Order : AggregateRoot<OrderId>
    {
        private Order()
        {
        }

        private readonly HashSet<LineItem> _lineItems = new();
        public AccountId AccountId { get; private set; } = null!;
        public decimal Total { get; private set; }
        public DateTime CreatedDate { get; private set; }

        public IReadOnlyList<LineItem> LineItems => _lineItems.ToList();

        public Order(
            OrderId orderId,
            AccountId accountId) : base(orderId)
        {
            AccountId = accountId;
        }

        public static Order Create(Account account)
        {
            return new(
                OrderId.CreateUnique(),
                account.Id);
        }
        
        public void Add(Product product)
        {
            var lineItem = new LineItem(
                LineItemId.CreateUnique(),
                Id,
                product.Id,
                product.Price
                );

            _lineItems.Add(lineItem);

        }
    }
}
