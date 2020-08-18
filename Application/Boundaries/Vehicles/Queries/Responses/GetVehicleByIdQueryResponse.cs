using Domain.Entities.Vehicles.Enum;

namespace Application.Boundaries.Vehicles.Queries.Responses
{
    public class GetVehicleByIdQueryResponse
    {
        public GetVehicleByIdQueryResponse()
        {
            
        }
        public GetVehicleByIdQueryResponse(int id, string brand, string model, 
            string color, string licensePlate, VehicleType type)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Color = color;
            LicensePlate = licensePlate;
            Type = type;
        }

        public int Id { get; set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string Color { get; private set; }
        public string LicensePlate { get; private set; }
        public VehicleType Type { get; private set; }
    }
}