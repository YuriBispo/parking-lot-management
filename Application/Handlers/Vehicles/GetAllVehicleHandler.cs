using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Boundaries.Vehicles.Queries.Requests;
using Application.Boundaries.Vehicles.Queries.Responses;
using Infra.InMemoryDataAccess.Repositories.IRepositories;
using MediatR;

namespace Application.Handlers.Vehicles
{
    public class GetAllVehicleHandler : IRequestHandler<GetAllVehiclesQuery, List<GetAllVehiclesQueryResponse>>
    {
        private IVehicleRepository _repository;

        public GetAllVehicleHandler(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllVehiclesQueryResponse>> 
            Handle(GetAllVehiclesQuery request, 
                CancellationToken cancellationToken)
        {
            var vehicles = _repository.GetAll().ToList();
            
            var allVehicles = new List<GetAllVehiclesQueryResponse>();
            foreach (var vehicle in vehicles)
            {
                allVehicles.Add(
                    new GetAllVehiclesQueryResponse(
                        vehicle.Id,
                        vehicle.Brand,
                        vehicle.Model,
                        vehicle.Color,
                        vehicle.LicensePlate,
                        vehicle.Type
                    )
                );
            };

            return await Task.FromResult(allVehicles);
        }
    }
}