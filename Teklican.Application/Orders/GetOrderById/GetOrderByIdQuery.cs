using MediatR;
using Teklican.Application.Wrapper;
using Teklican.Domain.Orders;

namespace Teklican.Application.Orders.GetOrderById
{
    public record GetOrderByIdQuery(Guid Id) : IRequest<Response<Order>>;

}
