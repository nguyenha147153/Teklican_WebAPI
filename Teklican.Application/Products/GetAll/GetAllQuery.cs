using MediatR;
using Teklican.Application.Wrapper;
using Teklican.Domain.Products;

namespace Teklican.Application.Products.GetAll
{
    public record GetAllQuery() : IRequest<Response<IEnumerable<Product>>>;
}
