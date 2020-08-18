using Domain.Entities.Vehicles.Enum;

namespace Application.Boundaries.Vehicles.Commands.Responses
{
    public class UpdateVehicleResponse
    {
        public UpdateVehicleResponse(int id, string brand, string model, 
            string color, string licensePlate, VehicleType type)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Color = color;
            LicensePlate = licensePlate;
            Type = type;
        }

        public int Id { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string Color { get; private set; }
        public string LicensePlate { get; private set; }
        public VehicleType Type { get; private set; }
    }
}