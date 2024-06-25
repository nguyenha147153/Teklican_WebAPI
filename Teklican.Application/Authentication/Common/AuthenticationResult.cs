using Teklican.Domain.Entities;

namespace Teklican.Application.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token);
}
