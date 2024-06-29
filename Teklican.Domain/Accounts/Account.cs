using Teklican.Domain.Models;
using Teklican.Domain.Roles.ValueObjects;
using Teklican.Domain.Users.ValueObjects;

namespace Teklican.Domain.Users
{
    public sealed class Account : AggregateRoot<AccountId>
    {
        private Account()
        {
        }
        public RoleId RoleId { get; set; } = null!;
        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string Password { get; private set; } = null!;
        public string Phone { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;
        public Account(
            AccountId accountId,
            string firstName,
            string lastName,
            string email,
            string password,
            string phone,
            string address) : base(accountId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Phone = phone;
            Address = address;
        }

        public static Account Create(
            string firstName,
            string lastName,
            string email,
            string password,
            string phone,
            string address)
        {
            return new(
                AccountId.CreateUnique(),
                firstName,
                lastName,
                email,
                password,
                phone,
                address);
        }
    }
}
