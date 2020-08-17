using System.Threading;
using System.Threading.Tasks;
using Application.Boundaries.Establishments.Commands.Requests;
using Application.Boundaries.Establishments.Commands.Responses;
using Domain.Entities.Addresses;
using Domain.Entities.Establishments;
using Domain.Entities.Establishments.ValueObjects;
using Infra.InMemoryDataAccess.Repositories.IRepositories;
using MediatR;

namespace Application.Handlers.Establishments
{
    public class CreateEstablishmentHandler
        : IRequestHandler<CreateEstablishmentRequest, CreateEstablishmentResponse>
    {
        private readonly IEstablishmentRepository _repository;

        public CreateEstablishmentHandler(IEstablishmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateEstablishmentResponse> Handle(
            CreateEstablishmentRequest request, 
            CancellationToken cancellationToken)
        {
            
            var establishment = new Establishment(new Name(request.Name), 
                new CNPJ(request.CNPJ),
                new Address(request.Address.Street, 
                    request.Address.Number,
                    request.Address.Neighbourhood,
                    request.Address.City,
                    request.Address.State,
                    request.Address.ZipCode,
                    request.Address.Complement),
                new Phone(request.Phone.CodeArea,
                    request.Phone.Number),
                request.CarsCapacity,
                request.MotorcyclesCapacity);

            var result = await _repository.Create(establishment.ToDataEntity());

            _repository.CommitChanges();

            return new CreateEstablishmentResponse(
                result.Id,
                result.Name,
                result.CNPJ,
                result.Address.ToString(),
                result.Phone,
                result.CarsCapacity,
                result.MotorcyclesCapacity
            );
        }
    }
}