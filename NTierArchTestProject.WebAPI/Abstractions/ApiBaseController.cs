using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NTierArchTestProject.WebAPI.Abstractions
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes ="Bearer")]//Her gelen api isteğinde header kısmında mutlaka token göndermiş olmamı umar 
    public abstract class ApiBaseController : ControllerBase
    {
        public readonly IMediator _mediator;
        protected ApiBaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
