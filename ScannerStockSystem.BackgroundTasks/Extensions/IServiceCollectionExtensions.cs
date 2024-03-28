using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Quartz.Impl;
using Quartz;
using ScannerStockSystem.BackgroundTasks.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScannerStockSystem.BackgroundTasks.Interfaces;
using ScannerStockSystem.BackgroundTasks.Services;

namespace ScannerStockSystem.BackgroundTasks.Extensions
{
   
    public static class IServiceCollectionExtensions
    {
        public static void AddBackgroundTasksLayer(this IServiceCollection services)
        {
            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {

            services.AddSingleton<IBlobService, BlobService>();
           // services.AddHostedService<QuartzHostedService>();
            services.AddHostedService<UploadBackgroundService>();
            
            services.AddSingleton<IScheduler>(provider =>
            {
                var schedulerFactory = new StdSchedulerFactory();
                return schedulerFactory.GetScheduler().GetAwaiter().GetResult();
            });

        }
    }
}
