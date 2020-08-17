using System;
using Domain.Entities;

namespace Domain.Data
{
    public sealed class Address : IDataEntity
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighbourhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public Address(int id, string street, string number, string complement, 
            string neighbourhood, string city, string state, string zipCode)
        {
            Id = id;
            Street = street;
            Number = number;
            Complement = complement;
            Neighbourhood = neighbourhood;
            City = city;
            State = state;
            ZipCode = zipCode;
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
    }
}