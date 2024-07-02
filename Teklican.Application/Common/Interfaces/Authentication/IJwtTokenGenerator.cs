using Teklican.Domain.Accounts;

namespace Teklican.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Account user);
    }
}
