using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScannerStockSystem.Application.Interfaces.Repositories;
using ScannerStockSystem.Persistence.Contexts;
using ScannerStockSystem.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using ScannerStockSystem.Application.Interfaces.Authentication;
using ScannerStockSystem.Persistence.Identity.Services;
using Microsoft.AspNetCore.Identity;
using ScannerStockSystem.Persistence.Identity.Data;
using ScannerStockSystem.Persistence.Identity.Models;

namespace ScannerStockSystem.Persistence.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddMappings();
            services.AddDbContext(configuration);
            services.AddIdentityConfig(configuration);
            services.AddIdentityDbContext(configuration);
            services.AddRepositories();
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            //var connectionString = configuration.GetConnectionString("DefaultConnection");
            var connectionString = configuration["ConnectionString"];
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(connectionString,
                   builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }
        public static void AddIdentityDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            //var connectionString = configuration.GetConnectionString("DefaultConnection");
            var connectionString = configuration["ConnectionString"];
            services.AddDbContext<AppIdentityContext>(options => options.UseSqlServer(connectionString,
                    b => b.MigrationsAssembly(typeof(AppIdentityContext).Assembly.FullName)
                ));

            services.AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<AppIdentityContext>()
            .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Default Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false; // For special character
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.User.RequireUniqueEmail = true;

            });

        }
        private static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddTransient<ICountryRepository, CountryRepository>()
                .AddTransient<ICountryRepository, CountryRepository>();
        }
        private static void AddIdentityConfig(this IServiceCollection services, IConfiguration configuration)
        {//======= > This methid should be in Infrastructure Layer
            services
                .AddScoped<IIdentityService, IdentityService>()// added
                .AddSingleton<ITokenGenerator>(new TokenGenerator(configuration["Jwt:Key"], configuration["Jwt:Issuer"], configuration["Jwt:Audience"], configuration["Jwt:ExpiryMinutes"]));// added
 
        }
    }
}
