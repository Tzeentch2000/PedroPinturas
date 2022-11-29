using System;
using System.Collections.Generic;
using System.Text;

namespace PedroPinturas.Exceptions
{
    internal class OutOfRangeException : Exception
    {
        public OutOfRangeException(string message) : base(message) { }
    }
}
