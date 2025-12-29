using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Commands.ProductCommands;
using NTierArchTestProject.BusinessLogicLayer.Features.CQRS.Queries.ProductQueries;
using NTierArchTestProject.WebAPI.Abstractions;
using NTierArchTestProject.WebAPI.Attributes;

namespace NTierArchTestProject.WebAPI.Controllers
{
    public class ProductController : ApiBaseController
    {
        public ProductController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        [RoleFilter("Product.Create")]
        public async Task<IActionResult> Create(CreateProductCommand p, CancellationToken cancellationToken)
        {
            var response= await _mediator.Send(p, cancellationToken);
            if (response.IsError) return BadRequest(response.FirstError);//"serviceResult"ErrorOg kütüphanesiyle kullanıp busines tarafta verdik
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut]
        [RoleFilter("Product.Update")]

        public async Task<IActionResult> Update(UpdateProductCommand p, CancellationToken cancellationToken)
        {
            await _mediator.Send(p, cancellationToken);
            return NoContent();
        }
        [HttpDelete]
        [RoleFilter("Product.Delete")]

        public async Task<IActionResult> Delete(DeleteProductCommand p, CancellationToken cancellationToken)
        {
            await _mediator.Send(p, cancellationToken);
            return NoContent();
        }
        [HttpGet]
        [RoleFilter("Product.GetAll")]

        public async Task<IActionResult> GetListAll(CancellationToken cancellationToken)
        {
            var values = await _mediator.Send(new GetAllProductQuery(), cancellationToken);
            return Ok(values);
        }
        [HttpGet("{id}")]
        [RoleFilter("Product.GetById")]

        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var value =await _mediator.Send(new GetProductByIdQuery(id), cancellationToken);
            return Ok(value);
        }
    }
}
