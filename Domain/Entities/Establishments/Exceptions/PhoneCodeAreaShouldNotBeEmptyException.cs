using System;

namespace Domain.Entities.Establishments.Exceptions
{
    public class PhoneCodeAreaShouldNotBeEmptyException : Exception
    {
        public PhoneCodeAreaShouldNotBeEmptyException(string message) : base(message)
        {
        }
    }
}