using MediatR;
using Teklican.Application.Wrapper;
using Teklican.Domain.Products;

namespace Teklican.Application.Products.GetById
{
    public record GetByIdQuery(Guid Id) : IRequest<Response<Product>>;
}
