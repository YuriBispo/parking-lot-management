using System;

namespace Domain.Entities.Vehicles.Exceptions
{
    public class BrandShouldNotBeEmptyException : Exception
    {
        public BrandShouldNotBeEmptyException(string message) : base(message)
        {
        }
    }
}