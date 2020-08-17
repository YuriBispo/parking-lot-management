using System;

namespace Domain.Entities.Establishments.Exceptions
{
    public class AddressFieldShouldNotBeEmpty : Exception
    {
        public AddressFieldShouldNotBeEmpty(string field) 
            : base(AddressFieldMessage(field))
        {
        }

        private static string AddressFieldMessage(string field) 
        {
            return $"Field \"{field}\" should not be empty";
        }
    }
}