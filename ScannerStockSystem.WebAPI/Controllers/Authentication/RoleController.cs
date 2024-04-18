using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScannerStockSystem.Application.Identity.Role.Create;

namespace ScannerStockSystem.WebAPI.Controllers.Authentication
{
 
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Create")]
        [ProducesDefaultResponseType(typeof(int))]
        public async Task<ActionResult> CreateRoleAsync(RoleCreateCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
