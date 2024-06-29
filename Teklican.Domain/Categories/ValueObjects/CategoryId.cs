using Teklican.Domain.Models;

namespace Teklican.Domain.Categories.ValueObjects
{
    public sealed class CategoryId : ValueObject
    {
        public Guid Value { get; }
        public CategoryId()
        {
        }
        public CategoryId(Guid value)
        {
            Value = value;
        }

        public static CategoryId CreateUnique()
        {
            return new CategoryId(Guid.NewGuid());
        }

        public static CategoryId Create(Guid value)
        {
            return new CategoryId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
