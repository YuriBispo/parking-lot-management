using System;

namespace Domain.Entities.Vehicles.Exceptions
{
    public class ModelShouldNotBeEmptyException : Exception
    {
        public ModelShouldNotBeEmptyException(string message) : base(message)
        {
        }
    }
}