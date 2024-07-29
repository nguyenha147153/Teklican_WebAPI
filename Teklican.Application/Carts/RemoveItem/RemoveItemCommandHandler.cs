using MediatR;
using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Application.Wrapper;
using Teklican.Domain.Carts.Entities;

namespace Teklican.Application.Carts.RemoveItem
{
    public class RemoveItemCommandHandler : IRequestHandler<RemoveItemCommand, Response<CartItem>>
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly ICartRepository _cartRepository;

        public RemoveItemCommandHandler(ICartItemRepository cartItemRepository, ICartRepository cartRepository) 
        {
            _cartItemRepository = cartItemRepository;
            _cartRepository = cartRepository;
        }

        public async Task<Response<CartItem>> Handle(RemoveItemCommand request, CancellationToken cancellationToken)
        {
            var cartItem = await _cartItemRepository.GetByIdAsync(request.CartItemId);

            if (cartItem is null)
            {
                return new Response<CartItem>("Sản phẩm không tồn tại trong giỏ hàng");
            }

            _cartItemRepository.Delete(cartItem);
            await _cartItemRepository.SaveChangesAsync(cancellationToken);

            if(_cartItemRepository.GetQueryable().FirstOrDefault(x=>x.CartId == cartItem.CartId) is null)
            {
                var cart = await _cartRepository.GetByIdAsync(cartItem.CartId.Value);
                _cartRepository.Delete(cart!);
                await _cartRepository.SaveChangesAsync(cancellationToken);
            }

            return new Response<CartItem>(cartItem, "Xóa sản phẩm khỏi giỏ hàng thành công");
        }
    }
}
