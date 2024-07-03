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

        public IEnumerable<Product> GetAll()
        {
            var listProduct = _dbContext.Products;
            return listProduct;
        }

        public Product? GetById(ProductId id)
        {
            var product = _dbContext.Products.Find(id.Value);
            return product;
        }

        public bool Create(Product product)
        {
            try
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Product product)
        {
            try
            {
                _dbContext.Products.Update(product);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(ProductId id)
        {
            try
            {
                var product = _dbContext.Products.Find(id.Value);

                if(product is null) 
                {
                    return false;
                }

                _dbContext.Products.Remove(product);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
