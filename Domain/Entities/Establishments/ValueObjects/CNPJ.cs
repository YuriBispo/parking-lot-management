using System;
using System.Collections.Generic;
using Domain.Entities.Establishments.Exceptions;

namespace Domain.Entities.Establishments.ValueObjects
{
    public class CNPJ : IEquatable<CNPJ>
    {
        private string _cnpj;

        public CNPJ(string cnpj)
        {
            if(string.IsNullOrWhiteSpace(cnpj))
                throw new CNPJShouldNotBeEmptyOrWhiteSpaceException(
                    "CNPJ should not be empty");

            _cnpj = cnpj;
        }

        public bool Equals(CNPJ other)
        {
            return _cnpj == other?._cnpj;
        }

        public override bool Equals(object obj)
        {
            return obj is CNPJ c && this.Equals(c);
        }

        public static bool operator ==(CNPJ left, CNPJ right) 
        {
            if(left is null && right is null)
                return true;

            return left.Equals(right);
        }

        public static bool operator !=(CNPJ left, CNPJ right) 
        {
            return left != right;
        }

        public override string ToString()
        {
            return Convert.ToUInt64(_cnpj).ToString(@"00\.000\.000\/0000\-00");
        }

        public override int GetHashCode()
        {
            return -1296379671 + EqualityComparer<string>.Default.GetHashCode(_cnpj);
        }
    }
}