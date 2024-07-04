using Microsoft.EntityFrameworkCore;
using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Domain.Categories;

namespace Teklican.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TeklicanDbContext _dbContext;

        public CategoryRepository(TeklicanDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Category category)
        {
            _dbContext.Add(category);
        }

        public void Delete(Category category)
        {
            _dbContext.Remove(category);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(CategoryId id)
        {
            return await _dbContext.Categories.FindAsync(id);
        }

        public void Update(Category category)
        {
            _dbContext.Categories.Update(category);
        }
        public Task SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

    }
}
