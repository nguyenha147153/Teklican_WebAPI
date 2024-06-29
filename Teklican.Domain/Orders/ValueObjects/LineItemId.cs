using Teklican.Domain.Models;

namespace Teklican.Domain.Orders.ValueObjects
{
    public sealed class LineItemId : ValueObject
    {
        public Guid Value { get; }
        public LineItemId()
        {
        }
        public LineItemId(Guid value)
        {
            Value = value;
        }

        public static LineItemId CreateUnique()
        {
            return new LineItemId(Guid.NewGuid());
        }

        public static LineItemId Create(Guid id)
        {
            return new LineItemId(id);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
