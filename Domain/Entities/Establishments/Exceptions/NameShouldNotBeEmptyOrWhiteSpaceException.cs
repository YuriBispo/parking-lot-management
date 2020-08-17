using System;

namespace Domain.Entities.Establishments.Exceptions
{
    public class NameShouldNotBeEmptyOrWhiteSpaceException : Exception
    {
        public NameShouldNotBeEmptyOrWhiteSpaceException(string message) 
            : base(message)
        {}
    }
}