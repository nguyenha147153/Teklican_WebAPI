using Microsoft.EntityFrameworkCore;
using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Domain.Products;

namespace Teklican.Infrastructure.Persistence.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private readonly TeklicanDbContext _dbContext;
        public ProductRepository(TeklicanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(ProductId id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public bool HasProduct(ProductId id)
        {
            return _dbContext.Products.Count(x=>x.Id == id) == 1;
        }

        public void Add(Product product)
        {
            _dbContext.Products.Add(product);
        }

        public void Update(Product product)
        {
            _dbContext.Update(product);
        }

        public void Delete(Product product)
        {
            _dbContext.Remove(product);
        }

        public IQueryable<Product> GetQueryable()
        {
            return _dbContext.Products.AsQueryable();
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
