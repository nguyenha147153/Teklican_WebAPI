using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teklican.Domain.Products.ValueObjects
{
    public record Sku
    {
        private const int DefaultLength = 15;
        private Sku(string value) => Value = value;
        public string Value { get; init; }
        public static Sku? Create(string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            if (value.Length != DefaultLength)
                return null;

            return new Sku(value);
        }
    };
}
