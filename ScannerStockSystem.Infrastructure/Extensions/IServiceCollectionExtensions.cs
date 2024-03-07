using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ScannerStockSystem.Application.Interfaces;
using ScannerStockSystem.Domain.Common.Interfaces;
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
                .AddTransient<IDomainEventDispatcher, IDomainEventDispatcher>()
                .AddTransient<IDateTimeService, DateTimeService>()
                .AddTransient<IEmailService, EmailService>();
        }
    }
}
