using Teklican.Domain.Models;

namespace Teklican.Domain.Orders.ValueObjects
{
    public sealed class OrderDetailId : ValueObject
    {
        public Guid Value { get; }

        public OrderDetailId(Guid value)
        {
            Value = value;
        }

        public static OrderDetailId CreateUnique()
        {
            return new OrderDetailId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
