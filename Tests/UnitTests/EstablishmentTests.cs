using System;
using Domain.Entities.Addresses;
using Domain.Entities.Establishments;
using Domain.Entities.Establishments.Exceptions;
using Domain.Entities.Establishments.ValueObjects;
using Newtonsoft.Json;
using Xunit;

namespace Tests.UnitTests
{
    public class EstablishmentTests
    {
        [Fact]
        public void Should_Load_Correctly()
        {
            var establishment = new Establishment(
                new Name("Estacionamento do seu Zé"),
                new CNPJ("23583549000151"),
                new Address("R. Dorival", "123", "Estoril", "BH", "MG", 
                    "32548542", "ap 1200"),
                new Phone("31", "31353437"),
                10,
                15
            );

            var expected = new {
                name = "Estacionamento do seu Zé",
                cnpj = "23.583.549/0001-51",
                address = "R. Dorival, nº 123, ap 1200, Estoril, BH, MG - 32548-542",
                phone = "(31)3135-3437",
                carsCap = 10,
                motorscyclesCap = 15
            };

            Assert.Equal(expected.name, 
                establishment.Name.ToString());
            Assert.Equal(expected.cnpj, establishment.CNPJ.ToString());
            Assert.Equal(expected.address, establishment.Address.ToString());
            Assert.Equal(expected.phone, establishment.Phone.ToString());
            Assert.Equal(expected.carsCap, establishment.CarsCapacity);
            Assert.Equal(expected.motorscyclesCap, 
                establishment.MotorcyclesCapacity);
        }

        [Fact]
        public void Should_Throw_Exception_If_Cars_Capacity_Is_Negative() 
        {
            Assert.ThrowsAny<Exception>(() => {
                var establishment = new Establishment(
                    new Name("Estacionamento do seu Zé"),
                    new CNPJ("23583549000151"),
                    new Address("R. Dorival", "123", "Estoril", "BH", "MG", 
                        "32548542", "ap 1200"),
                    new Phone("31", "31353437"),
                    -10,
                    0
                );  
            });
        }

        [Fact]
        public void Should_Throw_Exception_If_Motorcycles_Capacity_Is_Negative() 
        {
            Assert.ThrowsAny<Exception>(() => {
                var establishment = new Establishment(
                    new Name("Estacionamento do seu Zé"),
                    new CNPJ("23583549000151"),
                    new Address("R. Dorival", "123", "Estoril", "BH", "MG", 
                        "32548542", "ap 1200"),
                    new Phone("31", "31353437"),
                    10,
                    -5
                );  
            });
        }

        [Fact]
        public void Should_Throw_Exception_At_Loading_With_No_Parameters_Given() 
        {
            Assert.ThrowsAny<System.ArgumentException>(() => {
                var establishment = new Establishment(
                    null,
                    null,
                    null,
                    null,
                    0,
                    0
                );  
            });
        }

        [Fact]
        public void Should_Throw_Exception_At_Loading_With_No_Name_Given() 
        {
            Assert.ThrowsAny<Exception>(() => {
                var establishment = new Establishment(
                    new Name(""),
                    new CNPJ(""),
                    new Address("", "", "", "", "", 
                        "", ""),
                    new Phone("", ""),
                    0,
                    0
                );  
            });
        }

        [Fact]
        public void Should_Throw_Exception_At_Loading_With_No_CNPJ_Given() 
        {
            Assert.Throws<CNPJShouldNotBeEmptyOrWhiteSpaceException>(() => {
                var establishment = new Establishment(
                    new Name("Teste"),
                    new CNPJ(""),
                    new Address("", "", "", "", "", 
                        "", ""),
                    new Phone("", ""),
                    0,
                    0
                );  
            });
        }

        [Fact]
        public void Should_Throw_Exception_At_Loading_With_No_Address_Given() 
        {
            Assert.ThrowsAny<AddressFieldShouldNotBeEmpty>(() => {
                var establishment = new Establishment(
                    new Name("Teste"),
                    new CNPJ("01128525000170"),
                    new Address("", "", "", "", "", 
                        "", ""),
                    new Phone("", ""),
                    0,
                    0
                );  
            });
        }

        [Fact]
        public void Should_Throw_Exception_At_Loading_With_No_Phone_Given() 
        {
            Assert.ThrowsAny<PhoneCodeAreaShouldNotBeEmptyException>(() => {
                var establishment = new Establishment(
                    new Name("Teste"),
                    new CNPJ("01128525000170"),
                    new Address("R. Dorival", "123", "Estoril", "BH", "MG", 
                        "32548542", "ap 1200"),
                    new Phone("", ""),
                    0,
                    0
                );  
            });
        }

        [Fact]
        public void Should_Throw_Exception_At_Loading_With_No_Phone_Number_In_Invalid_Format() 
        {
            Assert.ThrowsAny<PhoneNumberInvalidFormatException>(() => {
                var establishment = new Establishment(
                    new Name("Teste"),
                    new CNPJ("01128525000170"),
                    new Address("R. Dorival", "123", "Estoril", "BH", "MG", 
                        "32548542", "ap 1200"),
                    new Phone("31", "5456546879554"),
                    2,
                    5
                );  
            });
        }

        [Fact]
        public void Should_Throw_Exception_At_Loading_With_No_CarsCapacity_Given() 
        {
            Assert.ThrowsAny<Exception>(() => {
                var establishment = new Establishment(
                    new Name("Teste"),
                    new CNPJ("01128525000170"),
                    new Address("R. Dorival", "123", "Estoril", "BH", "MG", 
                    "32548542", "ap 1200"),
                    new Phone("31", "31353437"),
                    0,
                    0
                );  
            });
        }

        [Fact]
        public void Should_Throw_Exception_At_Loading_With_No_Motorcycles_Given() 
        {
            Assert.ThrowsAny<Exception>(() => {
                var establishment = new Establishment(
                    new Name(""),
                    new CNPJ(""),
                    new Address("R. Dorival", "123", "Estoril", "BH", "MG", 
                    "32548542", "ap 1200"),
                    new Phone("", ""),
                    5,
                    0
                );  
            });
        }

        [Fact]
        public void Should_Return_Data_Entity() 
        {
            var establishment = new Establishment(
                new Name("Teste"),
                new CNPJ("01128525000170"),
                new Address("R. Dorival", "123", "Estoril", "BH", "MG", 
                "32548542", "ap 1200"),
                new Phone("31", "31353437"),
                2,
                3
            );

            var data = establishment.ToDataEntity();

            Assert.IsType<Domain.Data.Establishment>(data);
        }

        [Fact]
        public void Should_Load_Data_Entity_Correctly() 
        {
            var address = new Address("R. Dorival", "123", "Estoril", "BH", "MG", 
                "32548542", "ap 1200");

            var establishment = new Establishment(
                new Name("Estacionamento do seu Zé"),
                new CNPJ("23583549000151"),
                new Address("R. Dorival", "123", "Estoril", "BH", "MG", 
                    "32548542", "ap 1200"),
                new Phone("31", "31353437"),
                10,
                15
            );

            var dataEntity = establishment.ToDataEntity();

            var expected = new {
                name = "Estacionamento do seu Zé",
                cnpj = "23.583.549/0001-51",
                address = "R. Dorival, nº 123, ap 1200, Estoril, BH, MG - 32548-542",
                phone = "(31)3135-3437",
                carsCap = 10,
                motorscyclesCap = 15
            };

            var addressExpected = JsonConvert
                .SerializeObject(address.ToDataEntity());
            
            var addressResult = JsonConvert
                .SerializeObject(dataEntity.Address);

            Assert.Equal(expected.name, dataEntity.Name);
            Assert.Equal(expected.cnpj, dataEntity.CNPJ);
            Assert.Equal(addressExpected, addressResult);
            Assert.Equal(expected.phone, dataEntity.Phone);
            Assert.Equal(expected.carsCap, dataEntity.CarsCapacity);
            Assert.Equal(expected.motorscyclesCap, 
                dataEntity.MotorcyclesCapacity);
        }
    
        [Fact]
        public void Should_Add_A_Parking_Space_For_A_Car() 
        {
            var carsCapacity = 10;
            var establishment = new Establishment(
                new Name("Estacionamento do seu Zé"),
                new CNPJ("23583549000151"),
                new Address("R. Dorival", "123", "Estoril", "BH", "MG", 
                    "32548542", "ap 1200"),
                new Phone("31", "31353437"),
                carsCapacity,
                5
            );

            establishment.AddCarParkingSpace();

            Assert.Equal(carsCapacity + 1, establishment.CarsCapacity);
        }

        [Fact]
        public void Should_Remove_A_Parking_Space_For_A_Car() 
        {
            var carsCapacity = 10;
            var establishment = new Establishment(
                new Name("Estacionamento do seu Zé"),
                new CNPJ("23583549000151"),
                new Address("R. Dorival", "123", "Estoril", "BH", "MG", 
                    "32548542", "ap 1200"),
                new Phone("31", "31353437"),
                carsCapacity,
                5
            );

            establishment.RemoveCarParkingSpace();

            Assert.Equal(carsCapacity - 1, establishment.CarsCapacity);
        }

        [Fact]
        public void Should_Add_A_Parking_Space_For_A_Motorcycle() 
        {
            var motorcyclesCapacity = 7;
            var establishment = new Establishment(
                new Name("Estacionamento do seu Zé"),
                new CNPJ("23583549000151"),
                new Address("R. Dorival", "123", "Estoril", "BH", "MG", 
                    "32548542", "ap 1200"),
                new Phone("31", "31353437"),
                10,
                motorcyclesCapacity
            );

            establishment.AddMotocycleParkingSpace();

            Assert.Equal(motorcyclesCapacity + 1, 
                establishment.MotorcyclesCapacity);
        }

        [Fact]
        public void Should_Remove_A_Parking_Space_For_A_Motorcycle() 
        {
            var motorcyclesCapacity = 7;
            var establishment = new Establishment(
                new Name("Estacionamento do seu Zé"),
                new CNPJ("23583549000151"),
                new Address("R. Dorival", "123", "Estoril", "BH", "MG", 
                    "32548542", "ap 1200"),
                new Phone("31", "31353437"),
                10,
                motorcyclesCapacity
            );

            establishment.RemoveMotocycleParkingSpace();

            Assert.Equal(motorcyclesCapacity - 1, 
                establishment.MotorcyclesCapacity);
        }
    }
}