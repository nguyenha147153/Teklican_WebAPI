using Teklican.Domain.Models;

namespace Teklican.Domain.Category.ValueObjects
{
    public sealed class CategoryId : ValueObject
    {
        public Guid Value { get; }

        public CategoryId(Guid value)
        {
            Value = value;
        }

        public static CategoryId CreateUnique()
        {
            return new CategoryId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
