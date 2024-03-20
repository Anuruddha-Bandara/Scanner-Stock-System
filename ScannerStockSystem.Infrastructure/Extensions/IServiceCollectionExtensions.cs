using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ScannerStockSystem.Application.Features.Scanners.Commands.CreateScanner;
using ScannerStockSystem.Application.Interfaces;
using ScannerStockSystem.Domain.Common.Interfaces;
using ScannerStockSystem.Infrastructure.Handlers.DatabaseLoggers;
using ScannerStockSystem.Infrastructure.Services;


namespace ScannerStockSystem.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services
                .AddTransient<IMediator, Mediator>()
                .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>()
                .AddTransient<IDateTimeService, DateTimeService>()
                .AddTransient<IEmailService, EmailService>()
                .AddTransient<INotificationHandler<ScannerCreatedEvent>,DatabaseLogger>();
        }
    }
}
