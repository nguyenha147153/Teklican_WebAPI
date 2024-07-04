using MediatR;
using Teklican.Application.Wrapper;
using Teklican.Domain.Categories;

namespace Teklican.Application.Categories.Create
{
    public record CreateCategoryCommand(string Name) : IRequest<Response<Category>>;
}
