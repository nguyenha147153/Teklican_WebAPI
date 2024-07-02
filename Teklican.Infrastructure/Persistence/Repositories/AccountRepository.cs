using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Domain.Accounts;

namespace Teklican.Infrastructure.Persistence.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly TeklicanDbContext _dbContext;

        public AccountRepository(TeklicanDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Account user)
        {
            _dbContext.Accounts.Add(user);
            _dbContext.SaveChanges();
        }

        public Account? GetUserByEmail(string email)
        {
            return _dbContext.Accounts.SingleOrDefault(u => u.Email == email);
        }
    }
}
