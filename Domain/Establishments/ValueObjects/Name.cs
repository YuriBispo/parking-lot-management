using System;
using System.Collections.Generic;
using Domain.Establishments.Exceptions;

namespace Domain.Establishments.ValueObjects
{
    public class Name : IEquatable<Name>
    {
        private string _name;

        public Name(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new NameShouldNotBeEmptyOrWhiteSpaceException(
                    "Name should not be empty");

            _name = name;
        }

        public bool Equals(Name other)
        {
            return _name == other?._name;
        }

        public override bool Equals(object obj)
        {
            return obj is Name n && this.Equals(n);
        }

        public static bool operator ==(Name left, Name right) 
        {
            return left.Equals(right);
        }

        public static bool operator !=(Name left, Name right) 
        {
            return left != right;
        }

        // public override int GetHashCode()
        // {
        //     return HashCode.Combine(_name);
        // }

        public override string ToString()
        {
            return _name;
        }

        public override int GetHashCode()
        {
            return -1125283371 + EqualityComparer<string>.Default.GetHashCode(_name);
        }
    }
}