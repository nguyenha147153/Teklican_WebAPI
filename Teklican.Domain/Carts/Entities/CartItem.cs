using Teklican.Domain.Products;

namespace Teklican.Domain.Carts.Entities
{
    public sealed class CartItem
    {
        public CartItemId Id { get; set; } = null!;
        public CartId CartId { get; set; } = null!;
        public ProductId ProductId { get; set; } = null!;
        public int Quantity { get; set; }
        public Product Product { get; set; } = null!;

        internal CartItem(
           CartItemId cartItemId,
           CartId cartId,
           ProductId productId,
           int quantity)
        {
            Id = cartItemId;
            CartId = cartId;
            ProductId = productId;
            Quantity = quantity;
        }

        public static CartItem Create(
            CartId cartId,
            ProductId productId,
            int quantity)
        {
            return new(
                   new CartItemId(Guid.NewGuid()),
                   cartId,
                   productId,
                   quantity);
        }

        private CartItem()
        {
        }
    }
}
