using System.Drawing;
using Domain.Entities.Vehicles.Enum;
using Domain.Entities.Vehicles.Exceptions;
using Domain.Entities.Vehicles.ValueObjects;
using Color = Domain.Entities.Vehicles.ValueObjects.Color;

namespace Domain.Entities.Vehicles
{
    public class Vehicle : IDomainEntity<Data.Vehicle>
    {
        public int Id { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public Color Color { get; private set; }
        public LicensePlate LicensePlate { get; private set; }
        public VehicleType Type { get; private set; }

        public Vehicle(string brand, string model, Color color, LicensePlate licensePlate, VehicleType type)
        {
            if(string.IsNullOrWhiteSpace(brand))
                throw new BrandShouldNotBeEmptyException("Brand should not be empty");
            
            Brand = brand;

            if(string.IsNullOrWhiteSpace(model))
                throw new ModelShouldNotBeEmptyException("Model should not be empty");
            
            Model = model;
            Color = color;
            LicensePlate = licensePlate;
            Type = type;
        }

        public Data.Vehicle ToDataEntity()
        {
            return new Data.Vehicle(Id, Brand, Model, Color.ToString(), 
                LicensePlate.ToString(), VehicleType.Car);
        }
    }
}