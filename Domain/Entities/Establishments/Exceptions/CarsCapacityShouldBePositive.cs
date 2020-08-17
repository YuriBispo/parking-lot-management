using System;

namespace Domain.Entities.Establishments.Exceptions
{
    public class CarsCapacityShouldBePositive : Exception
    {
        public CarsCapacityShouldBePositive(string message) : base(message)
        {
        }
    }
}