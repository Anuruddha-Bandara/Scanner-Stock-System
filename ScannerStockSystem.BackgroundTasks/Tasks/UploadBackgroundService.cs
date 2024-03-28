using Microsoft.Extensions.Hosting;
using ScannerStockSystem.BackgroundTasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerStockSystem.BackgroundTasks.Tasks
{
    public class UploadBackgroundService : BackgroundService
    {
      
        private readonly IBlobService _blobService;

        public UploadBackgroundService(IBlobService blobService)
        {
            _blobService = blobService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
                while (!stoppingToken.IsCancellationRequested)
                {
                    var uploadInfo = _blobService.Dequeue();
                    if (uploadInfo is not null)
                    {
                        await _blobService.UploadBlobAsync(uploadInfo.ContainerName, uploadInfo.FileName, uploadInfo.ContentStream);
                    }
                    // Adjust as needed for the frequency of processing or polling the queue
                    await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
                }         
        }

      }    
}
public class UploadInfo
{
    public string ContainerName { get; set; }
    public string FileName { get; set; }
    public Stream ContentStream { get; set; }
}