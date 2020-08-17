using Application.Boundaries.Establishments.Commands.Responses;
using MediatR;

namespace Application.Boundaries.Establishments.Commands.Requests
{
    public class DeleteEstablishmentRequest : IRequest<DeleteEstablishmentResponse>
    {
        public DeleteEstablishmentRequest(int id)
        {
            Id = id;
        }

        public int Id { get;set; }
    }
}