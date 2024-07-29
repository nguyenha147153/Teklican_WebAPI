using MediatR;
using Teklican.Application.Wrapper;
using Teklican.Domain.Carts.Entities;

namespace Teklican.Application.Carts.RemoveItem
{
    public record RemoveItemCommand(Guid CartItemId) : IRequest<Response<CartItem>>;
}
