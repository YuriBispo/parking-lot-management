using System.Threading.Tasks;
using Application.Boundaries.Vehicles.Commands.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Vehicle
{
    [Route("/api/vehicles")]
    public class CreateVehicleController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(
            [FromServices]IMediator mediator,
            [FromBody] CreateVehicleRequest command)
        {
            var result = await mediator.Send(command);
            return Created("", result);
        }
    }
}