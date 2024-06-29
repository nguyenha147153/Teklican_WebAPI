using Teklican.Domain.Models;

namespace Teklican.Domain.Roles.ValueObjects
{
    public sealed class RoleId : ValueObject
    {
        public Guid Value { get; }
        public RoleId()
        {
        }
        public RoleId(Guid value)
        {
            Value = value;
        }

        public static RoleId CreateUnique()
        {
            return new RoleId(Guid.NewGuid());
        }

        public static RoleId Create(Guid value)
        {
            return new RoleId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
