using MediatR;
using Teklican.Application.Products.Common;
using Teklican.Application.Wrapper;
using Teklican.Domain.Products;

namespace Teklican.Application.Products.Update
{
    public record UpdateProductCommand(
            Guid Id,
            string Name,
            string Description,
            decimal Amount,
            string Current,
            string Sku,
            string Status,
            int CategoryId) : IRequest<Response<Product>>;
}
