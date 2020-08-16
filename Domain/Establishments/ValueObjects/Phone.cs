using System;
using System.Collections.Generic;

namespace Domain.Establishments.ValueObjects
{
    public class Phone : IEquatable<Phone>
    {
        private string _codeArea;
        private string _number;

        public Phone(string codeArea, string number)
        {
            _codeArea = codeArea;
            _number = number;
        }

        public bool Equals(Phone other)
        {
            return _codeArea == other?._codeArea &&
                _number == other?._number;
        }

        public override bool Equals(object obj)
        {
            return obj is Phone n && this.Equals(n);
        }

        public static bool operator ==(Phone left, Phone right) 
        {
            return left.Equals(right);
        }

        public static bool operator !=(Phone left, Phone right) 
        {
            return left != right;
        }

        // public override int GetHashCode()
        // {
        //     return HashCode.Combine(_name);
        // }

        public override string ToString()
        {
            var firstHalf = _number.Substring(0,4);
            var secondHalf = _number.Substring(4);

            return $"({_codeArea}){firstHalf}-{secondHalf}";
        }

        public override int GetHashCode()
        {
            int hashCode = -782814007;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_codeArea);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_number);
            return hashCode;
        }
    }
}