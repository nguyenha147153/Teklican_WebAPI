using Microsoft.EntityFrameworkCore;
using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Domain.Orders;

namespace Teklican.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(TeklicanDbContext context) : base(context) { }

        public override async Task<Order?> GetByIdAsync(Guid id)
        {
            return await _context.Orders
                .Include(x=>x.LineItems)
                .AsNoTracking()
                .AsSplitQuery()
                .SingleOrDefaultAsync(x=>x.Id == new OrderId(id));
        }
    }
}
