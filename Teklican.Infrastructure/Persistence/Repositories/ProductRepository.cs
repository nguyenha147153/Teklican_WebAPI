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
        public IEnumerable<Product> GetAll()
        {
            var listProduct = _dbContext.Products;
            return listProduct;
        }

        public Product? GetById(Guid id)
        {
            var product = _dbContext.Products.Find(id);
            return product;
        }
    }
}
