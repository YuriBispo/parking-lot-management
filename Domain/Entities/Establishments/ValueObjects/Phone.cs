using System;
using System.Collections.Generic;
using Domain.Entities.Establishments.Exceptions;

namespace Domain.Entities.Establishments.ValueObjects
{
    public class Phone : IEquatable<Phone>
    {
        private string _codeArea;
        private string _number;

        public Phone(string codeArea, string number)
        {
            if(string.IsNullOrWhiteSpace(codeArea))
            {
                throw new PhoneCodeAreaShouldNotBeEmptyException(
                    "Phone code area should not be empty"
                );
            }

            _codeArea = codeArea;

            if(number.Length > 11 || number.Length < 8) 
            {
                throw new PhoneNumberInvalidFormatException(
                    "Phone number should be around 10 to 11 digits. Do NOT use signs."
                );
            }

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
            if(left is null && right is null)
                return true;

            return left.Equals(right);
        }

        public static bool operator !=(Phone left, Phone right) 
        {
            return left != right;
        }

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