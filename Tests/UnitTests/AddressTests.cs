using Domain.Entities.Addresses;
using Domain.Entities.Establishments.Exceptions;
using Xunit;

namespace Tests.UnitTests
{
    public class AddressTests
    {
        [Fact]
        public void Should_Load_Correctly()
        {
            var establishment = new Address(
                "R. Dorival",
                "123",
                "Estoril",
                "BH",
                "MG",
                "32548542",
                "ap 1200"
            );

            var expected = new {
                street = "R. Dorival",
                number = "123",
                neighbourhood = "Estoril",
                city = "BH",
                state = "MG",
                zipCode = "32548542",
                complement = "ap 1200"  
            };

            Assert.Equal(expected.street, establishment.Street);
            Assert.Equal(expected.number, establishment.Number);
            Assert.Equal(expected.neighbourhood, establishment.Neighbourhood);
            Assert.Equal(expected.city, establishment.City);
            Assert.Equal(expected.zipCode, establishment.ZipCode);
            Assert.Equal(expected.complement, establishment.Complement);
        }

        [Fact]
        public void Should_Throw_Exception_At_Loading_With_With_No_Number_Given()
        {
            Assert.Throws<AddressFieldShouldNotBeEmpty>(() => {
                var establishment = new Address(
                    "R. Dorival",
                    "",
                    "Estoril",
                    "BH",
                    "MG",
                    "32548542",
                    "ap 1200"
                );
            });
        }

        [Fact]
        public void Should_Throw_Exception_At_Loading_With_With_No_Neighbouhood_Given()
        {
            Assert.Throws<AddressFieldShouldNotBeEmpty>(() => {
                var establishment = new Address(
                    "R. Dorival",
                    "123",
                    "",
                    "BH",
                    "MG",
                    "32548542",
                    "ap 1200"
                );
            });
        }

        [Fact]
        public void Should_Throw_Exception_At_Loading_With_With_No_City_Given()
        {
            Assert.Throws<AddressFieldShouldNotBeEmpty>(() => {
                var establishment = new Address(
                    "R. Dorival",
                    "123",
                    "Estoril",
                    "",
                    "MG",
                    "32548542",
                    "ap 1200"
                );
            });
        }

        [Fact]
        public void Should_Throw_Exception_At_Loading_With_With_No_State_Given()
        {
            Assert.Throws<AddressFieldShouldNotBeEmpty>(() => {
                var establishment = new Address(
                    "R. Dorival",
                    "123",
                    "Estoril",
                    "BH",
                    "",
                    "32548542",
                    "ap 1200"
                );
            });
        }

        [Fact]
        public void Should_Throw_Exception_At_Loading_With_With_No_ZipCode_Given()
        {
            Assert.Throws<AddressFieldShouldNotBeEmpty>(() => {
                var establishment = new Address(
                    "R. Dorival",
                    "123",
                    "Estoril",
                    "BH",
                    "MG",
                    "",
                    "ap 1200"
                );
            });
        }
    }
}