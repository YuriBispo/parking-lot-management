using System.Threading;
using System.Threading.Tasks;
using Application.Boundaries.Vehicles.Queries.Requests;
using Application.Boundaries.Vehicles.Queries.Responses;
using Infra.InMemoryDataAccess.Repositories.IRepositories;
using MediatR;

namespace Application.Handlers.Vehicles
{
    public class GetVehicleByIdHandler : IRequestHandler<GetVehicleByIdQuery, GetVehicleByIdQueryResponse>
    {
        private readonly IVehicleRepository _repository;

        public GetVehicleByIdHandler(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetVehicleByIdQueryResponse> 
            Handle(GetVehicleByIdQuery request, 
                CancellationToken cancellationToken)
        {
            var result = _repository.GetById(request.Id);
            
            return await Task.FromResult(
                new GetVehicleByIdQueryResponse(
                    result.Id,
                    result.Brand,
                    result.Model,
                    result.Color,
                    result.LicensePlate,
                    result.Type
                )
            );
        }
    }
}