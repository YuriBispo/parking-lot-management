using System.Threading;
using System.Threading.Tasks;
using Application.Boundaries.ParkingSpaces.Commands.Requests;
using Application.Boundaries.ParkingSpaces.Responses;
using Domain.Entities.Establishments;
using Infra.InMemoryDataAccess.Repositories.IRepositories;
using MediatR;

namespace Application.Handlers.ParkingSpaces
{
    public class ReleaseParkingSpaceHandler : IRequestHandler<ReleaseParkingSpaceRequest, ReleaseParkingSpaceResponse>
    {
        private IEstablishmentRepository _establishmentRepository;

        public ReleaseParkingSpaceHandler(IEstablishmentRepository establishmentRepository)
        {
            _establishmentRepository = establishmentRepository;
        }

        public Task<ReleaseParkingSpaceResponse> 
            Handle(ReleaseParkingSpaceRequest request, 
                CancellationToken cancellationToken)
        {
            var data = _establishmentRepository
                .GetById(request.EstablishmentId);

            var establishment = new Establishment(data);
            var totalPrice = establishment
                .ReleaseParkingSpace(request.ParkingSpaceId, request.VehicleId);
            
            _establishmentRepository.Update(establishment.ToDataEntity(request.EstablishmentId));

            _establishmentRepository.CommitChanges();

            return Task.FromResult(new 
                ReleaseParkingSpaceResponse(request.ParkingSpaceId, 
                    request.VehicleId, 
                    establishment
                        .IsParkingSpaceAvailable(request.ParkingSpaceId),
                    totalPrice.ToString()
                )
            );
        }
    }
}