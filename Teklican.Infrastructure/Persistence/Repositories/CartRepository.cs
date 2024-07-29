using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Domain.Accounts;
using Teklican.Domain.Carts;
using Teklican.Domain.Carts.Entities;

namespace Teklican.Infrastructure.Persistence.Repositories
{
    internal class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(TeklicanDbContext context) : base(context) { }

        public virtual async Task<Cart?> ListIncludeAsync(Expression<Func<Cart, bool>> predicate)
        {
            var query = _context.Set<Cart>().Include(x => x.CartItems).SingleOrDefaultAsync(predicate);

            if (query != null)
            {
                return await query;
            }

            return null;
        }

        public override async Task<Cart?> GetByIdAsync(Guid id)
        {
            return await _context.Carts.AsNoTracking().FirstAsync(x => x.Id == new CartId(id));
        }

        public virtual async Task<Cart?> ListCart(AccountId accountId)
        {
            var query = await _context.Set<Cart>().AsNoTracking()
                .Include(x => x.CartItems)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.AccountId == accountId);

            return query;
        }


        public bool HasCartInAccount(AccountId id)
        {
            return _context.Carts.Count(x=>x.AccountId == id) == 1;
        }
    }
}

