using Application.Boundaries.ParkingSpaces.Queries.Responses;
using MediatR;

namespace Application.Boundaries.ParkingSpaces.Queries.Requests
{
    public class CheckAvailableParkingSpacesQuery : IRequest<OccupyParkingSpaceQueryResponse>
    {
        public CheckAvailableParkingSpacesQuery(int establishmentId)
        {
            EstablishmentId = establishmentId;
        }

        public int EstablishmentId { get; set; }
    }
}