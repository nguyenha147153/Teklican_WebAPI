using MediatR;
using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Application.Wrapper;
using Teklican.Domain.Accounts;
using Teklican.Domain.Carts;
using Teklican.Domain.Products;

namespace Teklican.Application.Carts.AddItem
{
    public class AddItemCommandHandler : IRequestHandler<AddItemCommand, Response<Cart>>
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IProductRepository _productRepository;

        public AddItemCommandHandler(
            ICartRepository cartRepository,
            ICartItemRepository cartItemRepository,
            IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
        }
        public async Task<Response<Cart>> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            if(!_productRepository.HasProduct(new ProductId(request.ProductId)))
            { 
                return new Response<Cart>("Mã sản phẩm không tồn tại: " + request.ProductId);
            }

            var checkCart = await _cartRepository.ListIncludeAsync(x=>x.AccountId == new AccountId(request.AccountId));

            if(checkCart is null)
            {
                checkCart = Cart.Create(new AccountId(request.AccountId));
                _cartRepository.Insert(checkCart);
            }

            var cartItem = checkCart.AddCartItem(new ProductId(request.ProductId), checkCart.Id, request.Quantity);
            var checkCartItem = _cartItemRepository.GetQueryable().FirstOrDefault(x => x.CartId == checkCart.Id && x.ProductId == new ProductId(request.ProductId));

            if (checkCartItem is null)
            {
                _cartItemRepository.Insert(cartItem);
            }
            else
            {
                _cartItemRepository.Update(cartItem);
            }

            try
            {
                await _cartRepository.SaveChangesAsync(cancellationToken);
                await _cartItemRepository.SaveChangesAsync(cancellationToken);
                return new Response<Cart>(checkCart, "Thêm sản phẩm thành công: " + request.ProductId);
            }catch
            {
                return new Response<Cart>("Thêm sản phẩm thất bại");
            }

        }
    }
}
