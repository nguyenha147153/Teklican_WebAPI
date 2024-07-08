using System.Linq.Expressions;

namespace Teklican.Application.Common.Interfaces.Persistence
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> ListIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties);
        Task<TEntity?> GetByIdAsync(Guid id);
        IQueryable<TEntity> GetQueryable();
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
