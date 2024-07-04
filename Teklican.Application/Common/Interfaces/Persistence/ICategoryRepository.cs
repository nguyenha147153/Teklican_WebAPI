using Teklican.Domain.Categories;

namespace Teklican.Application.Common.Interfaces.Persistence
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(CategoryId id);
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
        Task SaveChangesAsync();
    }
}
