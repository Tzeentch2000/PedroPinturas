using System;
using System.Collections.Generic;
using System.Text;

namespace PedroPinturas.Exceptions
{
    internal class UsernameAlreadyExistException : Exception
    {
        //Nombre de usuario ya existe
        public UsernameAlreadyExistException(string message) : base(message) { }
    }
}
