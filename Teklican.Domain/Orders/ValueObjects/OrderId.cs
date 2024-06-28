using Teklican.Domain.Models;

namespace Teklican.Domain.Orders.ValueObjects
{
    public sealed class OrderId : ValueObject
    {
        public Guid Value { get; }

        public OrderId(Guid value)
        {
            Value = value;
        }

        public static OrderId CreateUnique()
        {
            return new OrderId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
