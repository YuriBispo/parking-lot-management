using System.Threading;
using System.Threading.Tasks;
using Application.Boundaries.Vehicles.Commands.Requests;
using Application.Boundaries.Vehicles.Commands.Responses;
using Infra.InMemoryDataAccess.Repositories.IRepositories;
using MediatR;

namespace Application.Handlers.Vehicles
{
    public class DeleteVehicleHandler : IRequestHandler<DeleteVehicleRequest, DeleteVehicleResponse>
    {
        private readonly IVehicleRepository _repository;

        public DeleteVehicleHandler(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteVehicleResponse> Handle(
            DeleteVehicleRequest request, 
            CancellationToken cancellationToken)
        {
            return await Task.FromResult(new 
                DeleteVehicleResponse(_repository.Delete(request.Id))
            );
        }
    }
}