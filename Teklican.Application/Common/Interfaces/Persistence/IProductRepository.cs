using Teklican.Domain.Products;

namespace Teklican.Application.Common.Interfaces.Persistence
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(ProductId id);
        bool HasProduct(ProductId id);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        IQueryable<Product> GetQueryable();
        Task SaveChangesAsync(CancellationToken cancellationToken);
    } 
}
