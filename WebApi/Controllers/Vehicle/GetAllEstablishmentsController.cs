using System.Threading.Tasks;
using Application.Boundaries.Vehicles.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Vehicle
{
    [Route("/api/vehicles")]
    public class GetAllVehiclesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(
            [FromServices]IMediator mediator
        )
        {
            var result = await mediator.Send(new GetAllVehiclesQuery());
            return Ok(result);
        }
    }
}