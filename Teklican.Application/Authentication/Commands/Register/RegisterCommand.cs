using MediatR;
using Teklican.Application.Authentication.Common;
using Teklican.Domain.Roles;

namespace Teklican.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        RoleId RoleId,
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string Phone,
        string Address) : IRequest<AuthenticationResult>;
}
