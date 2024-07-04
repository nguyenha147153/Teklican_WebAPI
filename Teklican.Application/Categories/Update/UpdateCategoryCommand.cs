using MediatR;
using Teklican.Application.Wrapper;
using Teklican.Domain.Categories;

namespace Teklican.Application.Categories.Update
{
    public record UpdateCategoryCommand(
        int Id,
        string Name) : IRequest<Response<Category>>;
}
