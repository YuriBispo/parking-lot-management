using System.Threading;
using System.Threading.Tasks;
using Application.Boundaries.ParkingSpaces.Commands.Requests;
using Application.Boundaries.ParkingSpaces.Responses;
using Domain.Entities.Establishments;
using Infra.InMemoryDataAccess.Repositories.IRepositories;
using MediatR;

namespace Application.Handlers.ParkingSpaces
{
    public class OccupyParkingSpaceHandler : IRequestHandler<OccupyParkingSpaceRequest, OccupyParkingSpaceResponse>
    {
        private IEstablishmentRepository _establishmentRepository;

        public OccupyParkingSpaceHandler(IEstablishmentRepository establishmentRepository)
        {
            _establishmentRepository = establishmentRepository;
        }

        public Task<OccupyParkingSpaceResponse> 
            Handle(OccupyParkingSpaceRequest request, 
                CancellationToken cancellationToken)
        {
            var data = _establishmentRepository
                .GetById(request.EstablishmentId);

            var establishment = new Establishment(data);
            establishment
                .OccupyParkingSpace(request.ParkingSpaceId, request.VehicleId);
            
            var result = _establishmentRepository
                .Update(establishment.ToDataEntity(request.EstablishmentId));

            _establishmentRepository.CommitChanges();

            return Task.FromResult(new 
                OccupyParkingSpaceResponse(request.ParkingSpaceId, 
                    request.VehicleId, 
                    establishment
                        .IsParkingSpaceAvailable(request.ParkingSpaceId)
                )
            );
        }
    }
}