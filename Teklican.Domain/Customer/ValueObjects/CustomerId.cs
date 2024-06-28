using Teklican.Domain.Models;

namespace Teklican.Domain.Customer.ValueObjects
{
    public sealed class CustomerId : ValueObject
    {
        public Guid Value { get;}

        public CustomerId(Guid value)
        {
            Value = value;
        }

        public static CustomerId CreateUnique()
        {
            return new CustomerId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
