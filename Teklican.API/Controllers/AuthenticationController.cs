using MediatR;
using Microsoft.AspNetCore.Mvc;
using Teklican.Application.Authentication.Commands.Register;
using Teklican.Application.Authentication.Common;
using Teklican.Application.Authentication.Queries;
using Teklican.Contracts.Authentication;

namespace Teklican.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ISender _mediator;

        public AuthenticationController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
            AuthenticationResult authResult = await _mediator.Send(command);

            return Ok(MapAuthResult(authResult));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = new LoginQuery(request.Email, request.Password);
            AuthenticationResult authResult = await _mediator.Send(query);

            return Ok(MapAuthResult(authResult));
        }

        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(
                            authResult.User.Id,
                            authResult.User.FirstName,
                            authResult.User.LastName,
                            authResult.User.Email,
                            authResult.Token
                            );
        }

    }
}
