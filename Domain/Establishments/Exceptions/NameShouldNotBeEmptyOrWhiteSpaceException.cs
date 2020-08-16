using System;

namespace Domain.Establishments.Exceptions
{
    public class NameShouldNotBeEmptyOrWhiteSpaceException : Exception
    {
        public NameShouldNotBeEmptyOrWhiteSpaceException(string message) 
            : base(message)
        {}
    }
}