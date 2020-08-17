using System.Threading.Tasks;
using Application.Boundaries.Establishments.Commands.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Establishment
{
    [Route("/api/teste")]
    public class UpdateEstablishmentController : ControllerBase
    {
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(
            [FromServices]IMediator mediator,
            [FromBody] UpdateEstablishmentRequest command,
            [FromRoute] int id)
        {

            command.Id = id;
            var result = mediator.Send(command);
            return Ok(result);
        }
    }
}