using System.Threading.Tasks;
using Application.Boundaries.ParkingSpaces.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.ParkingSpace
{
    public class CheckAvailableParkingSpacesController : ControllerBase
    {
        [HttpGet]
        [Route("/api/establishment/{establishmentId}/parking-spaces/available")]
        public async Task<IActionResult> Get(
            [FromServices] IMediator mediator,
            [FromRoute]int establishmentId
        )
        {
            var result = await mediator.Send(new 
                CheckAvailableParkingSpacesQuery(establishmentId)
            );
            return Ok(result);
        }
    }
}