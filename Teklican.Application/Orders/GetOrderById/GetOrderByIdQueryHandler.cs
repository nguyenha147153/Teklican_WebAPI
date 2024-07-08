using MediatR;
using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Application.Wrapper;
using Teklican.Domain.Orders;

namespace Teklican.Application.Orders.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Response<Order>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Response<Order>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);

            if (order is null)
            {
                return new Response<Order>("Mã đơn hàng không tồn tại: " + request.Id);
            }

            return new Response<Order>(order, "Lấy dữ liệu thành công");
        }
    }
}
