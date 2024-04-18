using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ScannerStockSystem.Application.Features.Scanners.Commands.CreateScanner;
using ScannerStockSystem.Application.Interfaces;
using ScannerStockSystem.Domain.Common.Interfaces;
using ScannerStockSystem.Infrastructure.Handlers.DatabaseLoggers;
using ScannerStockSystem.Infrastructure.Services;
using System.Text;


namespace ScannerStockSystem.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServices();
            services.AddAuth(configuration);
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
        public static IServiceCollection AddAuth( this IServiceCollection services,IConfiguration configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);

            services.AddSingleton(Options.Create(jwtSettings));
            // services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
                });

            return services;
        }
    }
    public class JwtSettings
    {
        public const string SectionName = "Authentication";
        public string SecretKey { get; init; } = null!;
        public int ExpiryMinutes { get; init; }
        public string Issuer { get; init; } = null!;
        public string Audience { get; init; } = null!;
    }
}
