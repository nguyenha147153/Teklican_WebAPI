﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teklican.Domain.Common.Exceptions
{
    public class UnauthorizationException : Exception
    {
        public UnauthorizationException(string msg) : base(msg) { }
    }
}
