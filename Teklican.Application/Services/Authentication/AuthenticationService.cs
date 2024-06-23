using Teklican.Application.Common.Interfaces.Authentication;
using Teklican.Application.Common.Interfaces.Persistence;
using Teklican.Domain.Common.Exceptions;
using Teklican.Domain.Common.Exceptions.Authentication;
using Teklican.Domain.Entities;

namespace Teklican.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        public AuthenticationService (IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            //1. Kiem tra user ko ton tai
            if(_userRepository.GetUserByEmail(email) is not null)
            {
                throw new DuplicateEmailException();
              /*  return Errors.User.DuplicateEmail;*/
            }
            //2. Tao user
            var user = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            _userRepository.Add(user);

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }

        public AuthenticationResult Login(string email, string password)
        {
            //1.Kiem tra user ton tai
            if(_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new EmaiInvalidException();
            }
            //2.Kiem tra password
            if(user.Password != password) 
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
