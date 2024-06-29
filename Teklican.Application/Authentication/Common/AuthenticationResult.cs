using Teklican.Domain.Users;

namespace Teklican.Application.Authentication.Common
{
    public record AuthenticationResult(
        Account User,
        string Token);
}
