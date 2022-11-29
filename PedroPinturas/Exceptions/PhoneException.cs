using System;
using System.Collections.Generic;
using System.Text;

namespace PedroPinturas.Exceptions
{
    internal class PhoneException : Exception
    {
        //Excepción de teléfono
        public PhoneException(string message) : base(message) { }
    }
}
