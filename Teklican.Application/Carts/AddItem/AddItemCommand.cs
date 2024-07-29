using MediatR;
using Teklican.Application.Wrapper;
using Teklican.Domain.Carts;

namespace Teklican.Application.Carts.AddItem
{
    public record AddItemCommand(
        Guid AccountId, 
        Guid ProductId, 
        int Quantity) : IRequest<Response<Cart>>;
}
