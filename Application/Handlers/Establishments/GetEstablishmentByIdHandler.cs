using System.Threading;
using System.Threading.Tasks;
using Application.Boundaries.Establishments.Queries.Requests;
using Application.Boundaries.Establishments.Queries.Responses;
using Infra.InMemoryDataAccess.Repositories.IRepositories;
using MediatR;

namespace Application.Handlers.Establishments
{
    public class GetEstablishmentByIdHandler : IRequestHandler<GetEstablishmentByIdQuery, GetEstablishmentByIdQueryResponse>
    {
        private readonly IEstablishmentRepository _repository;

        public GetEstablishmentByIdHandler(IEstablishmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetEstablishmentByIdQueryResponse> 
            Handle(GetEstablishmentByIdQuery request, 
                CancellationToken cancellationToken)
        {
            var result = _repository.GetById(request.Id);
            return await Task.FromResult(
                new GetEstablishmentByIdQueryResponse(
                    result.Id,
                    result.Name,
                    result.CNPJ,
                    result.Address.ToString(),
                    result.Phone,
                    result.CarsCapacity,
                    result.MotorcyclesCapacity
                )
            );
        }
    }
}