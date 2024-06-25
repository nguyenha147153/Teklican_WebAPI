using MediatR;
using Teklican.Application.Authentication.Common;
using Teklican.Application.Common.Interfaces.Authentication;
using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Domain.Common.Exceptions.Authentication;
using Teklican.Domain.Entities;

namespace Teklican.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            //1. Kiem tra user ko ton tai
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                throw new DuplicateEmailException();
                /*  return Errors.User.DuplicateEmail;*/
            }
            //2. Tao user
            var user = new User()
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password
            };

            _userRepository.Add(user);

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
