using Teklican.Domain.Accounts;
using Teklican.Domain.Carts.Entities;
using Teklican.Domain.Orders.Entities;
using Teklican.Domain.Products;

namespace Teklican.Domain.Carts
{
    public sealed class Cart
    {
        private readonly List<CartItem> _cartItems = new();
        private Cart()
        {
        }
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

        public CartItem AddCartItem(ProductId productId, CartId cartId, int quantity)
        {
            var cartItem = _cartItems.SingleOrDefault(x => x.CartId == cartId && x.ProductId == productId);

            if(cartItem is not null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
               cartItem = new CartItem(
               new CartItemId(Guid.NewGuid()),
               cartId,
               productId,
               quantity
               );
            }
            return cartItem;
        }

        /*private bool HasOneLineItem() => _cartItems.Count == 1;*/
    }
}
