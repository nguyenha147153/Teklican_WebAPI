using MediatR;
using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Application.Wrapper;
using Teklican.Domain.Orders;

namespace Teklican.Application.Orders.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, Response<IEnumerable<Order>>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetAllQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Response<IEnumerable<Order>>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var listOrder = await _orderRepository.ListIncludeAsync(x=>x.LineItems);
            
            return new Response<IEnumerable<Order>>(listOrder,"Lấy dữ liệu thành công");
        }
    }
}
