using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScannerStockSystem.Application.Features.Scanners.Commands.CreateScanner;
using ScannerStockSystem.Shared;

namespace ScannerStockSystem.WebAPI.Controllers
{



    public class ScannersController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public ScannersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreateScannerCommand command)
        {
            return await _mediator.Send(command);
        }


    }
}
