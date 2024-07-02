using Teklican.Domain.Accounts;

namespace Teklican.Application.Authentication.Common
{
    public record AuthenticationResult(
        Account User,
        string Token);
}
