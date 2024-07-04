using MediatR;
using Teklican.Application.Wrapper;
using Teklican.Domain.Categories;

namespace Teklican.Application.Categories.GetById
{
    public record GetByIdQuery(int Id) : IRequest<Response<Category>>;
}
