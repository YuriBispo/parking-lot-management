using System;
using System.Collections.Generic;
using Data = Domain.Data;

namespace Domain.Addresses
{
    public class Address
    {
        public string Street;
        public string Number;
        public string Complement;
        public string Neighbourhood;
        public string City;
        public string State;
        public string ZipCode;

        public Address(string street, string number, string neighbourhood,
            string city, string state, string zipCode, string complement)
        {
            if(string.IsNullOrWhiteSpace(street))
                throw new Exception();
                
            Street = street;
            
            if(string.IsNullOrWhiteSpace(number))
                throw new Exception();

            Number = number;

            if(string.IsNullOrWhiteSpace(neighbourhood))
                throw new Exception();
                
            Neighbourhood = neighbourhood;

            if(string.IsNullOrWhiteSpace(city))
                throw new Exception();

            City = city;

            if(string.IsNullOrWhiteSpace(state))
                throw new Exception();

            State = state;

            if(string.IsNullOrWhiteSpace(zipCode))
                throw new Exception();

            ZipCode = zipCode;

            if(string.IsNullOrWhiteSpace(complement))
                throw new Exception();

            Complement = complement;
        }

        public override bool Equals(object obj)
        {
            return obj is Address c && this.Equals(c);
        }

        public static bool operator ==(Address left, Address right) 
        {
            return left.Equals(right);
        }

        public static bool operator !=(Address left, Address right) 
        {
            return left != right;
        }

        public override string ToString()
        {
            var complement = "";
            if(!string.IsNullOrWhiteSpace(Complement))
                complement = $"{Complement},";

            return $"{Street}, nº {Number}, {complement} {Neighbourhood},"
                + $" {City}, {State} - {formatZipCode(ZipCode)}";
        }

        private string formatZipCode(string zipCode) 
        {
            return Convert.ToUInt64(zipCode).ToString(@"00000\-000");
        }

        public override int GetHashCode()
        {
            int hashCode = -396883702;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Street);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Number);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Complement);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Neighbourhood);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(City);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(State);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ZipCode);
            return hashCode;
        }

        public Data.Address ToDataEntity() {
            return new Data.Address(Street, Number, Complement, Neighbourhood, 
                City, State, ZipCode);
        }
    }
}