using System.Threading.Tasks;
using Application.Boundaries.Vehicles.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Vehicle
{
    [Route("/api/vehicles")]
    public class GetVehicleByIdController : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(
            [FromServices]IMediator mediator,
            [FromRoute] int id
        )
        {
            var result = await mediator.Send(new GetVehicleByIdQuery(id));
            return Ok(result);
        }
    }
}