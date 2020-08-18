using Application.Boundaries.ParkingSpaces.Responses;
using MediatR;

namespace Application.Boundaries.ParkingSpaces.Commands.Requests
{
    public class ReleaseParkingSpaceRequest : IRequest<ReleaseParkingSpaceResponse>
    {
        public int ParkingSpaceId { get; set; }
        public int VehicleId { get; set; }
        public int EstablishmentId { get; set; }
    }
}