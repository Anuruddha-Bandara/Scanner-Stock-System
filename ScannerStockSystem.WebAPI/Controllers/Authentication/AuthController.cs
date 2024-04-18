using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScannerStockSystem.Application.DTOs;
using ScannerStockSystem.Application.Identity.Auth;
using ScannerStockSystem.Application.Identity.Role.Create;

namespace ScannerStockSystem.WebAPI.Controllers.Authentication
{
    
     [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Login")]
        [ProducesDefaultResponseType(typeof(AuthResponseDTO))]
        public async Task<IActionResult> Login([FromBody] AuthCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
