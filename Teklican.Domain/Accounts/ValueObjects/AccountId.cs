using Teklican.Domain.Models;

namespace Teklican.Domain.Users.ValueObjects
{
    public sealed class AccountId : ValueObject
    {
        public Guid Value { get; }

        public AccountId()
        {
        }

        public AccountId(Guid value)
        {
            Value = value;
        }

        public static AccountId CreateUnique()
        {
            return new AccountId(Guid.NewGuid());
        }

        public static AccountId Create(Guid value)
        {
            return new AccountId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
