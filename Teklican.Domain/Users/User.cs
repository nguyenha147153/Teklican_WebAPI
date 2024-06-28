using Teklican.Domain.Models;
using Teklican.Domain.Users.ValueObjects;

namespace Teklican.Domain.Users
{
    public sealed class User : AggregateRoot<UserId>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public User(
            UserId userId,
            string firstName,
            string lastName,
            string email,
            string password) : base(userId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public static User Create(
            string firstName,
            string lastName,
            string email,
            string password)
        {
            return new(
                UserId.CreateUnique(),
                firstName,
                lastName,
                email,
                password);
        }
    }
}
