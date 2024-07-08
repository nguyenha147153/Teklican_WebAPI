using MediatR;
using Teklican.Application.Products.Common;
using Teklican.Application.Wrapper;
using Teklican.Domain.Products;

namespace Teklican.Application.Products.Create
{
    public record CreateProductCommand(
        string Name,
        string Description,
        decimal Amount,
        string Current,
        string Sku,
        string Status,
        int CategoryId
        ) : IRequest<Response<Product>>;
}
