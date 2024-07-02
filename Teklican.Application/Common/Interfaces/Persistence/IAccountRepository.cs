using Teklican.Domain.Accounts;

namespace Teklican.Application.Common.Interfaces.Persistence
{
    public interface IAccountRepository
    {
        Account? GetUserByEmail(string email);
        void Add(Account user);
    }
}
