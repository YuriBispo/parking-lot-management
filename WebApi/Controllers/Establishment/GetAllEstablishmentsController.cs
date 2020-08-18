using Application.Boundaries.Establishments.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Establishment
{
    [Route("/api/establishments")]
    public class GetAllEstablishmentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(
            [FromServices]IMediator mediator
        )
        {
            var result = mediator.Send(new GetAllEstablishmentsQuery());
            return Ok(result);
        }
    }
}