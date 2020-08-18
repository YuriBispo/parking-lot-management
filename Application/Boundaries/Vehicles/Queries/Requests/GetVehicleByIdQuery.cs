using Application.Boundaries.Vehicles.Queries.Responses;
using MediatR;

namespace Application.Boundaries.Vehicles.Queries.Requests
{
    public class GetVehicleByIdQuery : IRequest<GetVehicleByIdQueryResponse>
    {
        public GetVehicleByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}