using System;

namespace Domain.Entities.Addresses.Exceptions
{
    public class ZipCodeShouldNotBeEmptyException : Exception
    {
        public ZipCodeShouldNotBeEmptyException(string message) : base(message)
        {
        }
    }
}