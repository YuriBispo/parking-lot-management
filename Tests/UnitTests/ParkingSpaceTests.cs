using System.Threading;
using Domain.Entities.ParkingSpaces;
using Domain.Entities.ParkingSpaces.Enum;
using Moq;
using Xunit;

namespace Tests
{
    public class ParkingSpaceTests
    {
        [Fact]
        public void Should_Load_Entity_Correctly()
        {
            var parkingSpace = new ParkingSpace(ParkingSpaceType.Car);

            var expected = ParkingSpaceType.Car;

            Assert.Equal(expected, parkingSpace.Type);
        }

        [Fact]
        public void Should_Occupy_ParkingSpace_And_Then_Be_Not_Available()
        {
            var parkingSpace = new ParkingSpace(ParkingSpaceType.Car);

            parkingSpace.Occupy(2);
            
            Assert.False(parkingSpace.IsAvailable());
        }

        [Fact]
        public void Should_Not_Occupy_ParkingSpace_And_Return_Available()
        {
            var parkingSpace = new ParkingSpace(ParkingSpaceType.Car);
            
            Assert.True(parkingSpace.IsAvailable());
        }

        [Fact]
        public void Should_Release_ParkingSpace_And_Then_Be_Available()
        {
            var parkingSpace = new ParkingSpace(ParkingSpaceType.Car);

            parkingSpace.Occupy(2);
            parkingSpace.Release();
            
            Assert.True(parkingSpace.IsAvailable());
        }

        [Fact]
        public void Should_Not_Release_ParkingSpace_And_Return_Unavailable()
        {
            var parkingSpace = new ParkingSpace(ParkingSpaceType.Car);
            parkingSpace.Occupy(2);
            
            Assert.False(parkingSpace.IsAvailable());
        }

        [Fact]
        public void Should_Calculate_Time_Spent_On_ParkingSpace()
        {
            var parkingSpace = new ParkingSpace(ParkingSpaceType.Car);
            
            parkingSpace.Occupy(2);
            Thread.Sleep(2000); //2seg
            parkingSpace.Release();

            var expected = (double)2000 / 60000; //ms to min 

            Assert.Equal(expected.ToString("0.##"), 
                parkingSpace.CalculateTimeSpent().ToString("0.##"));
        }
        
        [Fact]
        public void Should_Return_Data_Entity_Correctly()
        {

            var parkingSpace = new ParkingSpace(ParkingSpaceType.Car);

            var expected = ParkingSpaceType.Car;

            var parkingSpaceData = parkingSpace.ToDataEntity();

            Assert.Equal(expected, parkingSpaceData.Type);
        }
    }
}