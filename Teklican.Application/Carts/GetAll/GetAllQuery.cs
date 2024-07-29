using MediatR;
using Teklican.Application.Wrapper;
using Teklican.Domain.Carts;

namespace Teklican.Application.Carts.GetAll
{
    public record GetAllQuery(Guid AccountId) : IRequest<Response<Cart>>;
}
