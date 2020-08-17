using System.Threading.Tasks;
using Application.Boundaries.Establishments.Commands.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Establishment
{
    [Route("/api/teste")]
    public class CreateEstablishmentController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(
            [FromServices]IMediator mediator,
            [FromBody] CreateEstablishmentRequest command)
        {
            var result = await mediator.Send(command);
            return Created("", result);
        }
    }
}