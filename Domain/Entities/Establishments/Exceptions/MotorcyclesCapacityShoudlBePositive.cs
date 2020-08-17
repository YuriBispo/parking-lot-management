using System;

namespace Domain.Entities.Establishments.Exceptions
{
    public class MotorcyclesCapacityShouldBePositive : Exception
    {
        public MotorcyclesCapacityShouldBePositive(string message) : base(message)
        {
        }
    }
}