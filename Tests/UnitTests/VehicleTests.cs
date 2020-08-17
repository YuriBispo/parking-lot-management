using Domain.Entities.Vehicles;
using Domain.Entities.Vehicles.Enum;
using Domain.Entities.Vehicles.Exceptions;
using Domain.Entities.Vehicles.ValueObjects;
using Xunit;

namespace Tests.UnitTests
{
    public class VehicleTests
    {
        [Fact]
        public void Should_Load_Entity_Correctly()
        {
            var vehicle = new Vehicle(
                "Audi",
                "R8 Spyder",
                new Color("Black"),
                new LicensePlate("YAZ5487"),
                VehicleType.Car
            );

            var expected = new {
                brand = "Audi",
                model = "R8 Spyder",
                color = "Black",
                licensePlate = "YAZ-5487",
                type = VehicleType.Car
            };

            Assert.Equal(expected.brand, vehicle.Brand);
            Assert.Equal(expected.model, vehicle.Model);
            Assert.Equal(expected.color, vehicle.Color.ToString());
            Assert.Equal(expected.licensePlate, vehicle.LicensePlate.ToString());
            Assert.Equal(expected.type, vehicle.Type);
        }

        [Fact]
        public void Should_Throw_Exception_At_Loading_With_No_Brand_Given()
        {
            Assert.ThrowsAny<BrandShouldNotBeEmptyException>(() => {
                var vehicle = new Vehicle(
                    "",
                    "R8 Spyder",
                    new Color("Black"),
                    new LicensePlate("YAZ5487"),
                    VehicleType.Car
                );
            });
        }

        [Fact]
        public void Should_Throw_Exception_At_Loading_With_No_Model_Given()
        {
            Assert.ThrowsAny<ModelShouldNotBeEmptyException>(() => {
                var vehicle = new Vehicle(
                    "Audi",
                    "",
                    new Color("Black"),
                    new LicensePlate("YAZ5487"),
                    VehicleType.Car
                );
            });
        }

        [Fact]
        public void Should_Throw_Exception_At_Loading_With_No_Color_Given()
        {
            Assert.ThrowsAny<ColorShouldNotBeEmptyException>(() => {
                var vehicle = new Vehicle(
                    "Audi",
                    "R8 Spyder",
                    new Color(""),
                    new LicensePlate("YAZ5487"),
                    VehicleType.Car
                );
            });
        }

        [Fact]
        public void Should_Throw_Exception_At_Loading_With_No_LicensePlate_Given()
        {
            Assert.ThrowsAny<LicensePlateShouldNotBeEmptyException>(() => {
                var vehicle = new Vehicle(
                    "Audi",
                    "R8 Spyder",
                    new Color("Black"),
                    new LicensePlate(""),
                    VehicleType.Car
                );
            });
        }

        [Fact]
        public void Should_Return_Data_Entity_Correctly()
        {
            var vehicle = new Vehicle(
                "Audi",
                "R8 Spyder",
                new Color("Black"),
                new LicensePlate("YAZ5487"),
                VehicleType.Car
            );

            var expected = new {
                brand = "Audi",
                model = "R8 Spyder",
                color = "Black",
                licensePlate = "YAZ-5487",
                type = VehicleType.Car
            };

            var vechicleData = vehicle.ToDataEntity();

            Assert.Equal(expected.brand, vechicleData.Brand);
            Assert.Equal(expected.model, vechicleData.Model);
            Assert.Equal(expected.color, vechicleData.Color);
            Assert.Equal(expected.licensePlate, vechicleData.LicensePlate);
            Assert.Equal(expected.type, vechicleData.Type);
        }
    }
}