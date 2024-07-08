using MediatR;
using Teklican.Application.Wrapper;
using Teklican.Domain.Orders;

namespace Teklican.Application.Orders.GetAll
{
    public record GetAllQuery() : IRequest<Response<IEnumerable<Order>>>;
}
