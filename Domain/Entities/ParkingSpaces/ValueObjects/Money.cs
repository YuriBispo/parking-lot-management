using System;
using System.Collections.Generic;

namespace Domain.Entities.ParkingSpaces.ValueObjects
{
    public class Money : IEquatable<Money>
    {
        private double _money;

        public Money(double money)
        {
            _money = money;
        }

        public bool Equals(Money other)
        {
            return _money == other._money;
        }

        public override bool Equals(object obj)
        {
            return obj is Money m && _money == m._money;
        }

        public override int GetHashCode()
        {
            return -1545276658 + EqualityComparer<double>
                .Default.GetHashCode(_money);
        }

        public override string ToString()
        {
            return $"R${_money}";
        }

        public double ToDouble()
        {
            return _money;
        }
    }
}