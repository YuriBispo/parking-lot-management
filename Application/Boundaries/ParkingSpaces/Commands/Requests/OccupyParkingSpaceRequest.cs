using Application.Boundaries.ParkingSpaces.Responses;
using MediatR;

namespace Application.Boundaries.ParkingSpaces.Commands.Requests
{
    public class OccupyParkingSpaceRequest : IRequest<OccupyParkingSpaceResponse>
    {
        public int ParkingSpaceId { get; set; }
        public int VehicleId { get; set; }
        public int EstablishmentId { get; set; }
    }
}