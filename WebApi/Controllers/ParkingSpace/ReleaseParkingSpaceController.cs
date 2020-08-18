using System.Threading.Tasks;
using Application.Boundaries.ParkingSpaces.Commands.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.ParkingSpace
{
    public class ReleaseParkingSpaceController : ControllerBase
    {
        [HttpPost]
        [Route("/api/establishment/{establishmentId}/parking-space/{parkingSpaceId}/release")]
        public async Task<IActionResult> OccupyPost(
            [FromServices] IMediator mediator,
            [FromBody] ReleaseParkingSpaceRequest command,
            [FromRoute]int establishmentId,
            [FromRoute]int parkingSpaceId)
        {
            command.EstablishmentId = establishmentId;
            command.ParkingSpaceId = parkingSpaceId;

            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}