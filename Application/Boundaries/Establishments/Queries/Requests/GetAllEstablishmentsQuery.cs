using System.Collections.Generic;
using Application.Boundaries.Establishments.Queries.Responses;
using MediatR;

namespace Application.Boundaries.Establishments.Queries.Requests
{
    public class GetAllEstablishmentsQuery : IRequest<List<GetAllEstablishmentsQueryResponse>>
    {
        public GetAllEstablishmentsQuery()
        {
            
        }
    }
}