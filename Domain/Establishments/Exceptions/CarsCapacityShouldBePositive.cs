using System;

namespace Domain.Establishments.Exceptions
{
    public class CarsCapacityShouldBePositive : Exception
    {
        public CarsCapacityShouldBePositive(string message) : base(message)
        {
        }
    }
}