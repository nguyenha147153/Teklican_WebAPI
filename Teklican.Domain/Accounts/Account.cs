using Teklican.Domain.Roles;

namespace Teklican.Domain.Accounts
{
    public sealed class Account 
    {
        public AccountId Id { get; private set; } = null!;
        public RoleId RoleId { get; private set; } = null!;
        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string Password { get; private set; } = null!;
        public string Phone { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;
        public Account(
            AccountId id,
            RoleId roleId,
            string firstName,
            string lastName,
            string email,
            string password,
            string phone,
            string address)
        {
            Id = id;
            RoleId = roleId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Phone = phone;
            Address = address;
        }

        public static Account Create(
            RoleId roleId,
            string firstName,
            string lastName,
            string email,
            string password,
            string phone,
            string address)
        {
            return new(
                new AccountId(Guid.NewGuid()),
                roleId,
                firstName,
                lastName,
                email,
                password,
                phone,
                address);
        }
        private Account()
        {
        }
    }
}
