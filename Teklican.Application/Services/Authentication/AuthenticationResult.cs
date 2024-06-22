using Teklican.Domain.Entities;

namespace Teklican.Application.Services.Authentication
{
    public record AuthenticationResult(
        User User,
        string Token);
}
