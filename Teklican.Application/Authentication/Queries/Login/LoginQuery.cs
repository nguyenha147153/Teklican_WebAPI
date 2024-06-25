using MediatR;
using Teklican.Application.Authentication.Common;

namespace Teklican.Application.Authentication.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password) : IRequest<AuthenticationResult>;
}
