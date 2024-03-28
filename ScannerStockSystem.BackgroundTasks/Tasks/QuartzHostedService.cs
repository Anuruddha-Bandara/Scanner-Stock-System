
using Quartz;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using ScannerStockSystem.BackgroundTasks.Interfaces;

namespace ScannerStockSystem.BackgroundTasks.Tasks
{


    public class QuartzHostedService : IHostedService
    {
         
        private readonly ILogger _logger;
        private readonly IScheduler _scheduler;
        private int executionCount = 0;
        private readonly IBlobService _blobServiceTest;

        public QuartzHostedService(ILogger<QuartzHostedService> logger, IScheduler scheduler, IBlobService blobService)
        {
            _logger = logger;
            _scheduler = scheduler;
            _blobServiceTest = blobService;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {



            //await _scheduler.Start(cancellationToken);
            while (!cancellationToken.IsCancellationRequested)
            {
                //    //executionCount++;

                //    //_logger.LogInformation(
                //    //    "Scoped Processing Service is working. Count: {Count}", executionCount);

                //    //await Task.Delay(1000);
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Quartz stopped...");
            await _scheduler.Shutdown(cancellationToken);
        }
    }
}