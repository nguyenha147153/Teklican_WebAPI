﻿using MediatR;
using Teklican.Application.Authentication.Common;
using Teklican.Application.Common.Interfaces.Authentication;
using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Domain.Accounts;
using Teklican.Domain.Common.Exceptions;
using Teklican.Domain.Common.Exceptions.Authentication;

namespace Teklican.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IAccountRepository _accountRepository;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IAccountRepository accountRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _accountRepository = accountRepository;
        }

        public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            //1.Kiem tra user ton tai
            if (_accountRepository.GetUserByEmail(query.Email) is not Account user)
            {
                throw new EmaiInvalidException();
            }

            //2.Kiem tra password
            if (user.Password != query.Password)
            {
                throw new PasswordInvalidException();
            }

            //3.Tao JWT Token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
