using System;
using System.Collections.Generic;
using System.Text;

namespace PedroPinturas.Exceptions
{
    internal class EmptyCharacterExceptions : Exception
    {
        public EmptyCharacterExceptions(string message) : base(message) { }
    }
}
