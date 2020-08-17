using System;

namespace Domain.Entities.Vehicles.Exceptions
{
    public class LicensePlateShouldNotBeEmptyException : Exception
    {
        public LicensePlateShouldNotBeEmptyException(string message) : base(message)
        {
        }
    }
}