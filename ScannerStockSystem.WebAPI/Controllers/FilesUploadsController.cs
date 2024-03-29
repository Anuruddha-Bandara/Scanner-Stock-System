using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScannerStockSystem.Application.Features.Customers.Commands.CreateCustomer;
using ScannerStockSystem.BackgroundTasks.Interfaces;
using ScannerStockSystem.WebAPI.Middlewares;
using System;

namespace ScannerStockSystem.WebAPI.Controllers
{
     
    public class FilesUploadsController : ApiControllerBase
    {
        private readonly IBlobService _blobService;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public FilesUploadsController(IBlobService blobService, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _blobService = blobService;
            _logger = logger;   
        }
        [HttpPost]
        public async Task<ActionResult<int>> Upload(CreateCustomerCommand command)
        {
            _logger.LogError(new Exception("EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE"), $"Exception occurred: EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
            throw new Exception();
            var ms = new MemoryStream();
            using (FileStream file = new FileStream("D:\\1698230125629.gif", FileMode.Open, FileAccess.Read))
               
            file.CopyTo(ms);
            ms.Seek(0, SeekOrigin.Begin);
            _blobService.Enqueue("sqldbauditlogs", $"{new Random().Next(100)}.gif", ms);
            return 0;
        }
    }
}
