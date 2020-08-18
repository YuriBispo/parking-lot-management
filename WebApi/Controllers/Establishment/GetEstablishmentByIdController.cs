using System.Threading.Tasks;
using Application.Boundaries.Establishments.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Establishment
{
    [Route("/api/establishments")]
    public class GetEstablishmentByIdController : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(
            [FromServices]IMediator mediator,
            [FromRoute] int id
        )
        {
            var result = await mediator.Send(new GetEstablishmentByIdQuery(id));
            return Ok(result);
        }
    }
}