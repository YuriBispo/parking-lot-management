namespace Application.Boundaries.ParkingSpaces.Responses
{
    public class ReleaseParkingSpaceResponse
    {
        public ReleaseParkingSpaceResponse(int parkingSpaceId,
            int vehicleId, 
            bool isAvailable,
            string totalPrice)
        {
            ParkingSpaceId = parkingSpaceId;
            VehicleId = vehicleId;
            IsAvailable = isAvailable;
            TotalPrice = totalPrice;
        }

        public int ParkingSpaceId { get; set; }
        public int VehicleId { get; set; }
        public bool IsAvailable { get; set; }
        public string TotalPrice { get; set; }
    }
}