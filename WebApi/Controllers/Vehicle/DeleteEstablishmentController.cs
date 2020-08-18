using System.Threading.Tasks;
using Application.Boundaries.Vehicles.Commands.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Vehicle
{
    [Route("/api/vehicles")]
    public class DeleteVehicleController : ControllerBase
    {
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(
            [FromServices]IMediator mediator,
            [FromRoute] int id)
        {
            var result = await mediator.Send(new DeleteVehicleRequest(id));
            return Ok(result);
        }
    }
}