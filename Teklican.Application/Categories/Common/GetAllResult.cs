using Teklican.Domain.Categories;

namespace Teklican.Application.Categories.Common
{
    public record GetAllResult(IEnumerable<Category> Categories);
}
