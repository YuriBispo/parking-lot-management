using System.Collections.Generic;
using Application.Boundaries.Vehicles.Queries.Responses;
using MediatR;

namespace Application.Boundaries.Vehicles.Queries.Requests
{
    public class GetAllVehiclesQuery : IRequest<List<GetAllVehiclesQueryResponse>>
    {
        
    }
}