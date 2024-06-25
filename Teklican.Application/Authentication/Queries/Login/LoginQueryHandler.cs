using MediatR;
using Teklican.Application.Authentication.Common;
using Teklican.Application.Common.Interfaces.Authentication;
using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Domain.Common.Exceptions;
using Teklican.Domain.Common.Exceptions.Authentication;
using Teklican.Domain.Entities;

namespace Teklican.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            //1.Kiem tra user ton tai
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
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
