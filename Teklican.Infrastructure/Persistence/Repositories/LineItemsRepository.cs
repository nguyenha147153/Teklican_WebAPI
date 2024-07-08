using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Domain.Orders.Entities;

namespace Teklican.Infrastructure.Persistence.Repositories
{
    internal class LineItemsRepository : Repository<LineItem>, ILineItemsRepository
    {
        public LineItemsRepository(TeklicanDbContext context) : base(context) { }
    }
}
