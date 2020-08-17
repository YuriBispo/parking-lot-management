using System;
using System.Collections.Generic;
using Domain.Entities.Establishments.Exceptions;
using Data = Domain.Data;

namespace Domain.Entities.Addresses
{
    public class Address
    {
        public int Id { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string Neighbourhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }

        public Address(string street, string number, string neighbourhood,
            string city, string state, string zipCode, string complement)
        {
            if(string.IsNullOrWhiteSpace(street))
                throw new AddressFieldShouldNotBeEmpty("street");
                
            Street = street;
            
            if(string.IsNullOrWhiteSpace(number))
                throw new AddressFieldShouldNotBeEmpty("number");

            Number = number;

            if(string.IsNullOrWhiteSpace(neighbourhood))
                throw new AddressFieldShouldNotBeEmpty("neighbourhood");
                
            Neighbourhood = neighbourhood;

            if(string.IsNullOrWhiteSpace(city))
                throw new AddressFieldShouldNotBeEmpty("city");

            City = city;

            if(string.IsNullOrWhiteSpace(state))
                throw new AddressFieldShouldNotBeEmpty("state");

            State = state;

            if(string.IsNullOrWhiteSpace(zipCode))
                throw new AddressFieldShouldNotBeEmpty("zipCode");

            ZipCode = zipCode;

            Complement = complement;
        }

        public override bool Equals(object obj)
        {
            return obj is Address c && this.Equals(c);
        }

        public static bool operator ==(Address left, Address right) 
        {
            if(left is null && right is null)
                return true;

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

        public Data.Address ToDataEntity() {
            return new Data.Address(Id, Street, Number, Complement, Neighbourhood, 
                City, State, ZipCode);
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
    }
}