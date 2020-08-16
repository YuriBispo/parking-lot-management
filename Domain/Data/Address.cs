namespace Domain.Data
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

        public Address(string street, string number, string complement, 
            string neighbourhood, string city, string state, string zipCode)
        {
            Street = street;
            Number = number;
            Complement = complement;
            Neighbourhood = neighbourhood;
            City = city;
            State = state;
            ZipCode = zipCode;
        }
    }
}