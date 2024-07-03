using Teklican.Domain.Products;

namespace Teklican.Application.Common.Interfaces.Persistence
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product? GetById(ProductId id);
        bool Create(Product product);
        bool Update(Product product);
        bool Delete(ProductId id);
    }
}
