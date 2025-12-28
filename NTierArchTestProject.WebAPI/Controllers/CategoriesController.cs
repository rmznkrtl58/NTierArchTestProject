using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.CategoryCommands;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Queries.CategoryQueries;
using NTierArchTestProject.WebAPI.Abstractions;
using NTierArchTestProject.WebAPI.Attributes;

namespace NTierArchTestProject.WebAPI.Controllers
{
    public class CategoriesController : ApiBaseController
    {
        public CategoriesController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        [RoleFilter("Category.Create")]

        public async Task<IActionResult> Create(CreateCategoryCommand p,CancellationToken cancellationToken)
        {
            await _mediator.Send(p, cancellationToken);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut]
        [RoleFilter("Category.Update")]

        public async Task<IActionResult> Update(UpdateCategoryCommand p,CancellationToken cancellationToken)
        {
           await _mediator.Send(p, cancellationToken);
            return NoContent();
        }
        [HttpDelete]
        [RoleFilter("Category.Delete")]

        public async Task<IActionResult> Delete(DeleteCategoryCommand p,CancellationToken cancellationToken)
        {
           await _mediator.Send(p, cancellationToken);
            return NoContent();
        }
        [HttpGet]
        [RoleFilter("Category.GetAll")]

        public async Task<IActionResult> GetListAll(CancellationToken cancellationToken)
        {
            var values =await _mediator.Send(new GetAllCategoryQuery(), cancellationToken);
            return Ok(values);
        }
        [HttpGet("{id}")]
        [RoleFilter("Category.GetById")]

        public async Task<IActionResult> GetById(Guid id,CancellationToken cancellationToken)
        {
            var value =await _mediator.Send(new GetCategoryByIdQuery(id), cancellationToken);
            return Ok(value);
        }
    }
}