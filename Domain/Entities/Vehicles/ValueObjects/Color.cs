using System;
using System.Collections.Generic;
using Domain.Entities.Vehicles.Exceptions;

namespace Domain.Entities.Vehicles.ValueObjects
{
    public class Color : IEquatable<Color>
    {
        private string _color;

        public Color(string color)
        {
            if(string.IsNullOrWhiteSpace(color))
                throw new ColorShouldNotBeEmptyException(color);

            _color = color;
        }

        public bool Equals(Color other)
        {
            return _color == other._color;
        }

        public override bool Equals(object obj)
        {
            return obj is Color c && this.Equals(c);
        }

        public override int GetHashCode()
        {
            return -1740376583 + EqualityComparer<string>.Default.GetHashCode(_color);
        }

        public override string ToString()
        {
            return _color;
        }
    }
}