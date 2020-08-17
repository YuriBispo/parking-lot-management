using System.Collections.Generic;
using Application.Boundaries.Establishments.Queries.Responses;
using MediatR;

namespace Application.Boundaries.Establishments.Queries.Requests
{
    public class GetEstablishmentByIdQuery : IRequest<GetEstablishmentByIdQueryResponse>
    {
        public GetEstablishmentByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}