using System;
using System.Collections.Generic;
using System.Text;

namespace PacoPinturas.Exceptions
{
    internal class PhoneException : Exception
    {
        //Excepción de teléfono
        public PhoneException(string message) : base(message) { }
    }
}
