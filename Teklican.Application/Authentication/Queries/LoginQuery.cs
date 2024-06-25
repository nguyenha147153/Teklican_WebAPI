using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teklican.Application.Authentication.Common;

namespace Teklican.Application.Authentication.Queries
{
    public record LoginQuery(
        string Email, 
        string Password) : IRequest<AuthenticationResult>;
}
