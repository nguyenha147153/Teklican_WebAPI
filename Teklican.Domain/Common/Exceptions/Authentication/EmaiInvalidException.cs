using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teklican.Domain.Common.Exceptions.Authentication
{
    public class EmaiInvalidException : Exception
    {
        public EmaiInvalidException() : base("Email chưa được đăng kí") { }
    }
}
