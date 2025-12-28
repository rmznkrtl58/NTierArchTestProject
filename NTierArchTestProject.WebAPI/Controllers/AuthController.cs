using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.AuthCommands;
using NTierArchTestProject.WebAPI.Abstractions;

namespace NTierArchTestProject.WebAPI.Controllers
{
    [AllowAnonymous]
    public sealed class AuthController : ApiBaseController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommand p,CancellationToken cancellationToken)
        {
            await _mediator.Send(p, cancellationToken);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand p, CancellationToken cancellationToken)
        {
            var response= await _mediator.Send(p, cancellationToken);
            return Ok(response);
        }
    }
}
