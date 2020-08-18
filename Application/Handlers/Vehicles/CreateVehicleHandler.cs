using System.Threading;
using System.Threading.Tasks;
using Application.Boundaries.Vehicles.Commands.Requests;
using Application.Boundaries.Vehicles.Commands.Responses;
using Domain.Entities.Vehicles;
using Domain.Entities.Vehicles.Enum;
using Domain.Entities.Vehicles.ValueObjects;
using Infra.InMemoryDataAccess.Repositories.IRepositories;
using MediatR;

namespace Application.Handlers.Vehicles
{
    public class CreateVehicleHandler
        : IRequestHandler<CreateVehicleRequest, CreateVehicleResponse>
    {
        private readonly IVehicleRepository _repository;

        public CreateVehicleHandler(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateVehicleResponse> Handle(
            CreateVehicleRequest request, 
            CancellationToken cancellationToken)
        {
            var vehicle = new Vehicle(
                request.Brand,
                request.Model,
                new Color(request.Color),
                new LicensePlate(request.LicensePlate),
                VehicleType.Car
            );

            var result = await _repository.Create(vehicle.ToDataEntity());

            _repository.CommitChanges();

            return new CreateVehicleResponse(
                result.Id,
                result.Brand,
                result.Model,
                result.Color,
                result.LicensePlate,
                result.Type
            );
        }
    }
}