using Teklican.Domain.Users;

namespace Teklican.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Account user);
    }
}
