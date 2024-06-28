using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teklican.Domain.Customer.ValueObjects;
using Teklican.Domain.Models;

namespace Teklican.Domain.Users.ValueObjects
{
    public sealed class UserId : ValueObject
    {
        public Guid Value { get; }

        public UserId(Guid value)
        {
            Value = value;
        }

        public static UserId CreateUnique()
        {
            return new UserId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
