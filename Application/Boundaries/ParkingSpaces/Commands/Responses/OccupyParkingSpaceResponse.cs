namespace Application.Boundaries.ParkingSpaces.Responses
{
    public class OccupyParkingSpaceResponse
    {
        public OccupyParkingSpaceResponse()
        {
            
        }
        public OccupyParkingSpaceResponse(int parkingSpaceId,
            int vehicleId, 
            bool isAvailable)
        {
            ParkingSpaceId = parkingSpaceId;
            VehicleId = vehicleId;
            IsAvailable = isAvailable;
        }

        public int ParkingSpaceId { get; set; }
        public int VehicleId { get; set; }
        public bool IsAvailable { get; set; }
    }
}