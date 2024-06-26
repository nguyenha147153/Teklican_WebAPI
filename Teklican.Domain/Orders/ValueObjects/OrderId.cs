﻿using Teklican.Domain.Models;

namespace Teklican.Domain.Orders.ValueObjects
{
    public sealed class OrderId : ValueObject
    {
        public Guid Value { get; }
        public OrderId()
        {
        }
        public OrderId(Guid value)
        {
            Value = value;
        }

        public static OrderId CreateUnique()
        {
            return new OrderId(Guid.NewGuid());
        }

        public static OrderId Create(Guid id)
        {
            return new OrderId(id);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
