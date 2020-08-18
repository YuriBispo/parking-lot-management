using Domain.Entities;
using Domain.Entities.ParkingSpaces.Enum;
using Newtonsoft.Json;

namespace Domain.Data
{
    public class ParkingSpace : IDataEntity    
    {
        public int Id { get; set; }
        public ParkingSpaceType Type { get; set; }
        public double PricePerHour { get; set; }
        public int? VehicleId { get; set; }
        [JsonIgnore]
        public Vehicle Vehicle { get; set; }
        
        public ParkingSpace(int id, ParkingSpaceType type, int? vehicleId)
        {
            Id = id;
            Type = type;
            PricePerHour = PricePerHour;
            VehicleId = vehicleId;
        }
    }
}