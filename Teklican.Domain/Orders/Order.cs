using Teklican.Domain.Accounts;
using Teklican.Domain.Orders.Entities;
using Teklican.Domain.Products;
using Teklican.Domain.Products.ValueObjects;

namespace Teklican.Domain.Orders
{
    public sealed class Order 
    {
        private readonly HashSet<LineItem> _lineItems = new();
        public OrderId Id { get; private set; } = null!;
        public AccountId AccountId { get; private set; } = null!;
        public decimal Total { get; private set; }
        public DateTime CreatedDate { get; private set; }

        public IReadOnlyList<LineItem> LineItems => _lineItems.ToList();

        public Order(
            OrderId orderId,
            AccountId accountId)
        {
            Id = orderId;
            AccountId = accountId;
        }

        public static Order Create(AccountId accountId)
        {
            return new(
                new OrderId(Guid.NewGuid()),
                accountId);
        }
        
        public void Add(ProductId productId, Money price)
        {
            var lineItem = new LineItem(
                new LineItemId(Guid.NewGuid()),
                Id,
                productId,
                price
                );

            _lineItems.Add(lineItem);
        }
        private Order()
        {
        }
    }
}
