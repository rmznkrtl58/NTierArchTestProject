using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.AuthCommands;
using NTierArchTestProject.WebAPI.Abstractions;
using System.Data;

namespace NTierArchTestProject.WebAPI.Controllers
{
    public sealed class UserRolesController : ApiBaseController
    {
        public UserRolesController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public async Task<IActionResult> AssignRoleToUser(SetUserRoleCommand p,CancellationToken cancellationToken)
        {
            await _mediator.Send(p, cancellationToken);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
