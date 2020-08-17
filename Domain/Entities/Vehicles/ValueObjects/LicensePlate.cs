using System;
using System.Collections.Generic;
using Domain.Entities.Vehicles.Exceptions;

namespace Domain.Entities.Vehicles.ValueObjects
{
    public class LicensePlate : IEquatable<LicensePlate>
    {
        private string _licensePlate;

        public LicensePlate(string licensePlate)
        {
            if(string.IsNullOrWhiteSpace(licensePlate))
                throw new LicensePlateShouldNotBeEmptyException("Licnse plate should not"
                    + "be empty");

            _licensePlate = licensePlate;
        }

        public override bool Equals(object obj)
        {
            return obj is LicensePlate plate &&
                _licensePlate == plate._licensePlate;
        }

        public bool Equals(LicensePlate other)
        {
            return _licensePlate == other._licensePlate;
        }

        public override int GetHashCode()
        {
            return -796771785 + EqualityComparer<string>.Default.GetHashCode(_licensePlate);
        }

        public override string ToString()
        {
            var letters =_licensePlate.Substring(0,3);
            var numbers =_licensePlate.Substring(3);

            return $"{letters}-{numbers}";
        }
    }
}