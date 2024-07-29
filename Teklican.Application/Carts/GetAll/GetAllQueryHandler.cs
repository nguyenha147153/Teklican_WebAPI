using MediatR;
using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Application.Wrapper;
using Teklican.Domain.Accounts;
using Teklican.Domain.Carts;

namespace Teklican.Application.Carts.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, Response<Cart>>
    {
        private readonly ICartRepository _cartRepository;

        public GetAllQueryHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<Response<Cart>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.ListCart(new AccountId(request.AccountId));

            if(cart is null)
            {
                return new Response<Cart>("Giỏ hàng trống, vui lòng thêm sản phẩm");
            }

            return new Response<Cart>(cart,"Lấy dữ liệu thành công");
        }
    }
}
