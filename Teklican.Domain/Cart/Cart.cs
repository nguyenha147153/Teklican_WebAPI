using Teklican.Domain.Accounts;
using Teklican.Domain.Cart.Entities;

namespace Teklican.Domain.Cart
{
    public sealed class Cart
    {
        private readonly List<CartItem> _cartItems = new();
        public CartId Id { get; private set; } = null!;
        public AccountId AccountId { get; private set; } = null!;
        public DateTime CreatedDate { get; private set; }
        public IReadOnlyList<CartItem> CartItems => _cartItems.AsReadOnly();

        public Cart(
            CartId cartId,
            AccountId accountId)
        {
            Id = cartId;
            AccountId = accountId;
        }

        public static Cart Create(AccountId accountId)
        {
            return new(
                new CartId(Guid.NewGuid()),
                accountId);
        }

        /*  public void Add(ProductId productId, Money price)
          {
              var lineItem = new LineItem(
                  new LineItemId(Guid.NewGuid()),
                  Id,
                  productId,
                  price
                  );

              _lineItems.Add(lineItem);
          }*/
        private Cart()
        {
        }
    }
}
