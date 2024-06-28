using Teklican.Domain.Models;

namespace Teklican.Domain.Products.ValueObjects
{
    public sealed class ProductId : ValueObject
    {
        public Guid Value { get; }

        public ProductId(Guid value)
        {
            Value = value;
        }

        public static ProductId CreateUnique()
        {
            return new ProductId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
