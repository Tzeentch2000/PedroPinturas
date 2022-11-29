using System;
using System.Collections.Generic;
using System.Text;

namespace PedroPinturas.Exceptions
{
    internal class IncorrectUserException : Exception
    {
        //Excepción de login
        public IncorrectUserException(string message) : base(message) { }
    }
}
