using MediatR;
using Teklican.Application.Wrapper;
using Teklican.Domain.Products;

namespace Teklican.Application.Products.Delete
{
    public record DeleteProductCommand(Guid Id) : IRequest<Response<Product>>;
}
