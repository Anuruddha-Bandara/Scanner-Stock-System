using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScannerStockSystem.Application.Features.MasterDatas.Commands.CreateMasterData;
using ScannerStockSystem.Shared;

namespace ScannerStockSystem.WebAPI.Controllers
{

    public class MasterDatasController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public MasterDatasController(IMediator mediator)
        {
            _mediator = mediator;
        }    
        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreateMasterDataCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
