using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teklican.Domain.Common.Exceptions
{
    public class PasswordInvalidException : Exception
    {
        public PasswordInvalidException() : base("Password không hợp lệ") { }
    }
}
