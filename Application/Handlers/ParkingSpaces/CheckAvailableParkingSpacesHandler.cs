using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Boundaries.ParkingSpaces.Queries.Requests;
using Application.Boundaries.ParkingSpaces.Queries.Responses;
using Domain.Entities.Establishments;
using Infra.InMemoryDataAccess.Repositories.IRepositories;
using MediatR;

namespace Application.Handlers.ParkingSpaces
{
    public class CheckAllParkingSpacesAvailableHandler 
        : IRequestHandler<CheckAvailableParkingSpacesQuery, 
            OccupyParkingSpaceQueryResponse>
    {
        private readonly IEstablishmentRepository _repository;

        public CheckAllParkingSpacesAvailableHandler(
            IEstablishmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<OccupyParkingSpaceQueryResponse> 
            Handle(CheckAvailableParkingSpacesQuery request, 
                CancellationToken cancellationToken)
        {
            var data = _repository.GetById(request.EstablishmentId);
            var establishment = new Establishment(data);
            
            return await Task.FromResult(new OccupyParkingSpaceQueryResponse(
                establishment.CheckAvailableParkingSpaces()
            ));
        }
    }
}