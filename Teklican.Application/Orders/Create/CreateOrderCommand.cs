using MediatR;
using Teklican.Application.Wrapper;
using Teklican.Domain.Orders;

namespace Teklican.Application.Orders.Create
{
    public record CreateOrderCommand(
            Guid AccountId,
            List<LineItemsCommand> LineItems
        ) : IRequest<Response<Order>>;

    public record LineItemsCommand(
            Guid ProductId,
            decimal Amount,
            string Currency,
            int Quantity,
            decimal SubTotal);
}
