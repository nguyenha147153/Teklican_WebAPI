﻿using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teklican.Application.Authentication.Commands.Register;
using Teklican.Application.Authentication.Common;
using Teklican.Application.Authentication.Queries.Login;
using Teklican.Contracts.Authentication;

namespace Teklican.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
            AuthenticationResult authResult = await _mediator.Send(command);

            return Ok(_mapper.Map<AuthenticationResponse>(authResult));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request); 
            AuthenticationResult authResult = await _mediator.Send(query);

            return Ok(_mapper.Map<AuthenticationResponse>(authResult));
        }
    }
}
