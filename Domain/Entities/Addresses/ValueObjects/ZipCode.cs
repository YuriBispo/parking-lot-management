using System;
using System.Collections.Generic;
using Domain.Entities.Addresses.Exceptions;

namespace Domain.Entities.Addresses.ValueObjects
{
    public class ZipCode
    {
        private string _zipCode;

        public ZipCode(string zipCode)
        {
            if(string.IsNullOrWhiteSpace(zipCode))
                throw new ZipCodeShouldNotBeEmptyException(
                    "ZipCode should not be empty");

            if(_zipCode.Length != 8)
                throw new ZipCodeInvalidFormatException("Make sure zipCode has 8 digits. Do NOT use signs");

            _zipCode = zipCode;
        }

        public bool Equals(ZipCode other)
        {
            return _zipCode == other?._zipCode;
        }

        public override bool Equals(object obj)
        {
            return obj is ZipCode c && this.Equals(c);
        }

        public static bool operator ==(ZipCode left, ZipCode right) 
        {
            return left.Equals(right);
        }

        public static bool operator !=(ZipCode left, ZipCode right) 
        {
            return left != right;
        }

        public override string ToString()
        {
            return Convert.ToUInt64(_zipCode).ToString(@"00\.000\.000\/0000\-00");
        }

        public override int GetHashCode()
        {
            return 1496281004 + EqualityComparer<string>.Default.GetHashCode(_zipCode);
        }
    }
}