using System;

namespace Domain.Entities.Establishments.Exceptions
{
    public class PhoneNumberInvalidFormatException : Exception
    {
        public PhoneNumberInvalidFormatException(string message) : base(message)
        {
        }
    }
}