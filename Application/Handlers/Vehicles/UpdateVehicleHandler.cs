using System.Threading;
using System.Threading.Tasks;
using Application.Boundaries.Vehicles.Commands.Requests;
using Application.Boundaries.Vehicles.Commands.Responses;
using Domain.Entities.Addresses;
using Domain.Entities.Vehicles;
using Domain.Entities.Vehicles.ValueObjects;
using Infra.InMemoryDataAccess.Repositories.IRepositories;
using MediatR;

namespace Application.Handlers.Vehicles
{
    public class UpdateVehicleHandler
        : IRequestHandler<UpdateVehicleRequest, UpdateVehicleResponse>
    {
        private readonly IVehicleRepository _repository;

        public UpdateVehicleHandler(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateVehicleResponse> Handle(
            UpdateVehicleRequest request, 
            CancellationToken cancellationToken)
        {
            
            var vehicle = new Vehicle(
                request.Brand,
                request.Model,
                new Color(request.Color),
                new LicensePlate(request.LicensePlate),
                request.Type
            );

            var result = _repository.Update(vehicle.ToDataEntity(request.Id));

            _repository.CommitChanges();

            return await Task.FromResult(new UpdateVehicleResponse(
                result.Id,
                result.Brand,
                result.Model,
                result.Color,
                result.LicensePlate,
                result.Type
            ));
        }
    }
}