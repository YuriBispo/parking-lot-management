using Application.Boundaries.Vehicles.Commands.Responses;
using MediatR;

namespace Application.Boundaries.Vehicles.Commands.Requests
{
    public class DeleteVehicleRequest : IRequest<DeleteVehicleResponse>
    {
        public DeleteVehicleRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}