using System.Linq.Expressions;
using Teklican.Domain.Accounts;
using Teklican.Domain.Carts;

namespace Teklican.Application.Common.Interfaces.Persistence
{
    public interface ICartRepository : IRepository<Cart>
    {
        Task<Cart?> ListIncludeAsync(Expression<Func<Cart, bool>> predicate);
        bool HasCartInAccount(AccountId id);
        Task<Cart?> ListCart(AccountId accountId);
    }
}
