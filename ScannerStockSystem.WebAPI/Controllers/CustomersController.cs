using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScannerStockSystem.Application.Features.Countries.Commands.CreateCountry;
using ScannerStockSystem.Application.Features.Customers.Commands.CreateCustomer;
using ScannerStockSystem.Shared;

namespace ScannerStockSystem.WebAPI.Controllers
{
 
    public class CustomersController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreateCustomerCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}