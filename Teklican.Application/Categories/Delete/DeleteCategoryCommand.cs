using MediatR;
using Teklican.Application.Wrapper;
using Teklican.Domain.Categories;

namespace Teklican.Application.Categories.Delete
{
    public record DeleteCategoryCommand(int Id) : IRequest<Response<Category>>;
}
