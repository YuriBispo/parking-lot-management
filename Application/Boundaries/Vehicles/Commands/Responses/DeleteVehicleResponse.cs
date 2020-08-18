namespace Application.Boundaries.Vehicles.Commands.Responses
{
    public class DeleteVehicleResponse
    {
        public DeleteVehicleResponse()
        {
            
        }
        public DeleteVehicleResponse(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}