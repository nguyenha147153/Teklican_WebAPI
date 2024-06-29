using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teklican.Domain.Products.ValueObjects
{
    public record Money(string Currency, decimal Amount);
}
