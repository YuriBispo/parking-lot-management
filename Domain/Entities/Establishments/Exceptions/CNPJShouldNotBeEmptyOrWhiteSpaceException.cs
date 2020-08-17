using System;

namespace Domain.Entities.Establishments.Exceptions
{
    public class CNPJShouldNotBeEmptyOrWhiteSpaceException : Exception
    {
        public CNPJShouldNotBeEmptyOrWhiteSpaceException(string message) 
            : base(message)
        {}
    }
}