using System.Threading.Tasks;
using Application.Boundaries.Establishments.Commands.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Establishment
{
    [Route("/api/teste")]
    public class DeleteEstablishmentController : ControllerBase
    {
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(
            [FromServices]IMediator mediator,
            [FromRoute] int id)
        {
            var result = await mediator.Send(new DeleteEstablishmentRequest(id));
            return Ok(result);
        }
    }
}