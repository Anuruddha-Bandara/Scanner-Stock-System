using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScannerStockSystem.Application.Interfaces.Repositories;
using ScannerStockSystem.Persistence.Contexts;
using ScannerStockSystem.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ScannerStockSystem.Persistence.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddMappings();
            services.AddDbContext(configuration);
            services.AddRepositories();
        }

        //private static void AddMappings(this IServiceCollection services)
        //{
        //    services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //}

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            //var connectionString = configuration.GetConnectionString("DefaultConnection");
            var connectionString = configuration["ConnectionString"];
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(connectionString,
                   builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddTransient<ICountryRepository, CountryRepository>()
                //.AddTransient<IClubRepository, ClubRepository>()
                //.AddTransient<IStadiumRepository, StadiumRepository>()
                .AddTransient<ICountryRepository, CountryRepository>();
        }
    }
}
