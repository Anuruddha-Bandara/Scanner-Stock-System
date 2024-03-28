using Microsoft.AspNetCore.Mvc;
using ScannerStockSystem.Application.Features.Customers.Commands.CreateCustomer;
using ScannerStockSystem.BackgroundTasks.Interfaces;

namespace ScannerStockSystem.WebAPI.Controllers
{
     
    public class FilesUploadsController : ApiControllerBase
    {
        private readonly IBlobService _blobService;

        public FilesUploadsController(IBlobService blobService)
        {
            _blobService = blobService;
        }
        [HttpPost]
        public async Task<ActionResult<int>> Upload(CreateCustomerCommand command)
        {
            var ms = new MemoryStream();
            using (FileStream file = new FileStream("D:\\1698230125629.gif", FileMode.Open, FileAccess.Read))
               
            file.CopyTo(ms);
            ms.Seek(0, SeekOrigin.Begin);
            _blobService.Enqueue("sqldbauditlogs", $"{new Random().Next(100)}.gif", ms);
            return 0;
        }
    }
}
