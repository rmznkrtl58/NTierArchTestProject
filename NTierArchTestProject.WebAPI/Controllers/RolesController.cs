using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.AuthCommands;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Queries.AuthQueries;
using NTierArchTestProject.WebAPI.Abstractions;

namespace NTierArchTestProject.WebAPI.Controllers
{
    public class RolesController : ApiBaseController
    {
        public RolesController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRoles(CancellationToken cancellationToken)
        {
            var values = await _mediator.Send(new GetAllRoleQuery(), cancellationToken);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleCommand p,CancellationToken cancellationToken)
        {
            await _mediator.Send(p, cancellationToken);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
