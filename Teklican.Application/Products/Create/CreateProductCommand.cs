using MediatR;
using Teklican.Application.Products.Common;

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
        ) : IRequest<ProductResult>;
}
