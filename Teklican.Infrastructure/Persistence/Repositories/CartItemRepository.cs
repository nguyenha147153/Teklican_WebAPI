using Microsoft.EntityFrameworkCore;
using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Domain.Carts.Entities;
using Teklican.Domain.Orders;

namespace Teklican.Infrastructure.Persistence.Repositories
{
    internal class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(TeklicanDbContext context) : base(context) { }
       
        public override async Task<CartItem?> GetByIdAsync(Guid id)
        {
            return await _context.CartItems.FindAsync(new CartItemId(id));
        }
    }
}
