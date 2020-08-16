using System;

namespace Domain.Establishments.Exceptions
{
    public class CNPJShouldNotBeEmptyOrWhiteSpaceException : Exception
    {
        public CNPJShouldNotBeEmptyOrWhiteSpaceException(string message) 
            : base(message)
        {}
    }
}