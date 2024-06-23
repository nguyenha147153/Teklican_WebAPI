using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teklican.Domain.Common.Exceptions.Authentication
{
    public class DuplicateEmailException : Exception
    {
        public DuplicateEmailException() : base("Email đã tồn tại") { }
    }
}
