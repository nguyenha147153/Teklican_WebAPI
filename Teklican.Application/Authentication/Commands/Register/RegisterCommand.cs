﻿using MediatR;
using Teklican.Application.Authentication.Common;

namespace Teklican.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password) : IRequest<AuthenticationResult>;
}
