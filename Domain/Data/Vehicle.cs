using Domain.Entities;
using Domain.Entities.Vehicles.Enum;

namespace Domain.Data
{
    public class Vehicle : IDataEntity
    {
        public int Id { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string Color { get; private set; }
        public string LicensePlate { get; private set; }
        public VehicleType Type { get; private set; }

        public Vehicle(int id, string brand, string model, string color, 
            string licensePlate, VehicleType type)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Color = color;
            LicensePlate = licensePlate;
            Type = type;
        }
    }
}