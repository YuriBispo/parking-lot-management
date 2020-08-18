using System.Threading.Tasks;
using Application.Boundaries.Vehicles.Commands.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Vehicle
{
    [Route("/api/vehicles")]
    public class UpdateVehicleController : ControllerBase
    {
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(
            [FromServices]IMediator mediator,
            [FromBody] UpdateVehicleRequest command,
            [FromRoute] int id)
        {
            command.Id = id;
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}