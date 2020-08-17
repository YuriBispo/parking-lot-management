using System;

namespace Domain.Entities.Vehicles.Exceptions
{
    public class ColorShouldNotBeEmptyException : Exception
    {
        public ColorShouldNotBeEmptyException(string message) : base(message)
        {
        }
    }
}