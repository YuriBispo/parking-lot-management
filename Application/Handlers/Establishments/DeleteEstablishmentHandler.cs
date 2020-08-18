using System.Threading;
using System.Threading.Tasks;
using Application.Boundaries.Establishments.Commands.Requests;
using Application.Boundaries.Establishments.Commands.Responses;
using Infra.InMemoryDataAccess.Repositories.IRepositories;
using MediatR;

namespace Application.Handlers.Establishments
{
    public class DeleteEstablishmentHandler : IRequestHandler<DeleteEstablishmentRequest, DeleteEstablishmentResponse>
    {
        private readonly IEstablishmentRepository _repository;

        public DeleteEstablishmentHandler(IEstablishmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteEstablishmentResponse> Handle(
            DeleteEstablishmentRequest request, 
            CancellationToken cancellationToken)
        {
            return await Task.FromResult(new 
                DeleteEstablishmentResponse(_repository.Delete(request.Id))
            );
        }
    }
}