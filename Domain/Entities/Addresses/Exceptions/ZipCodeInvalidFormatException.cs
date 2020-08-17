using System;

namespace Domain.Entities.Addresses.Exceptions
{
    public class ZipCodeInvalidFormatException : Exception
    {
        public ZipCodeInvalidFormatException(string message) : base(message)
        {
        }
    }
}