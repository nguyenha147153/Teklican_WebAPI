using Teklican.Domain.Products;

namespace Teklican.Application.Common.Interfaces.Persistence
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product? GetById(Guid id);
    }
}
