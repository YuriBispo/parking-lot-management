using Domain.Entities;
using Domain.Entities.ParkingSpaces.Enum;

namespace Domain.Data
{
    public class ParkingSpace : IDataEntity    
    {
        public int Id { get; set; }
        public ParkingSpaceType Type { get; set; }
        
        public ParkingSpace(int id, ParkingSpaceType type)
        {
            Id = id;
            Type = type;
        }
    }
}