using Teklican.Domain.Users;

namespace Teklican.Application.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token);
}
