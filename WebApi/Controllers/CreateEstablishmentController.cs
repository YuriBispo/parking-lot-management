using System.Threading.Tasks;
using Application.Boundaries.Establishments.Commands.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("/api/teste")]
    public class CreateEstablishmentController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(
            [FromServices]IMediator mediator,
            [FromBody] CreateEstablishmentRequest command)
        {
            var result = mediator.Send(command);
            return Created("", result);
        }
    }
}