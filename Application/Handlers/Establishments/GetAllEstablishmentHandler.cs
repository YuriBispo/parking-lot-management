using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Boundaries.Establishments.Queries.Requests;
using Application.Boundaries.Establishments.Queries.Responses;
using Infra.InMemoryDataAccess.Repositories.IRepositories;
using MediatR;

namespace Application.Handlers.Establishments
{
    public class GetAllEstablishmentHandler : IRequestHandler<GetAllEstablishmentsQuery, List<GetAllEstablishmentsQueryResponse>>
    {
        private IEstablishmentRepository _repository;

        public GetAllEstablishmentHandler(IEstablishmentRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetAllEstablishmentsQueryResponse>> Handle(GetAllEstablishmentsQuery request, CancellationToken cancellationToken)
        {
            var establishments = _repository.GetAll().ToList();
            
            var allEstablishments = new List<GetAllEstablishmentsQueryResponse>();
            foreach (var establishment in establishments)
            {
                allEstablishments.Add(
                    new GetAllEstablishmentsQueryResponse(
                        establishment.Id,
                        establishment.Name,
                        establishment.CNPJ,
                        establishment.Address.ToString(),
                        establishment.Phone,
                        establishment.CarsCapacity,
                        establishment.MotorcyclesCapacity
                    )
                );
            };

            return Task.FromResult(allEstablishments);
        }
    }
}