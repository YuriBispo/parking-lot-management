using System;

namespace Domain.Establishments.Exceptions
{
    public class AddressFieldShouldNotBeEmpty : Exception
    {
        public AddressFieldShouldNotBeEmpty(string field, string message) 
            : base(AddressFieldMessage(field, message))
        {
        }

        private static string AddressFieldMessage(string field, string message) 
        {
            return $"Field \"{field}\" should not be empty";
        }
    }
}