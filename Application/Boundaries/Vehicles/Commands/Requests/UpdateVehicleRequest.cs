using Application.Boundaries.Vehicles.Commands.Responses;
using Domain.Entities.Vehicles.Enum;
using MediatR;

namespace Application.Boundaries.Vehicles.Commands.Requests
{
    public class UpdateVehicleRequest : IRequest<UpdateVehicleResponse>
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string LicensePlate { get; set; }
        public VehicleType Type { get; set; }
    }
}