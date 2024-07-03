using MediatR;
using Teklican.Application.Authentication.Common;
using Teklican.Application.Products.Common;

namespace Teklican.Application.Products.Create
{
    public record CreateProductCommand(
        string Name,
        string Description,
        decimal Amount,
        string Sku,
        string Status,
        int CategoryId
        ) : IRequest<ProductResult>;
}
