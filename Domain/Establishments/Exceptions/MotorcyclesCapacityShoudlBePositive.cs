using System;

namespace Domain.Establishments.Exceptions
{
    public class MotorcyclesCapacityShouldBePositive : Exception
    {
        public MotorcyclesCapacityShouldBePositive(string message) : base(message)
        {
        }
    }
}