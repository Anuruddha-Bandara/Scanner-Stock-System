using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScannerStockSystem.Application.Identity.User.CreateUser;

namespace ScannerStockSystem.WebAPI.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        [ProducesDefaultResponseType(typeof(int))]
        public async Task<ActionResult> CreateUser(CreateUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
         
    }
}
