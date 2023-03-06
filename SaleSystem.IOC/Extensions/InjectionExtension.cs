using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaleSystem.DAL.Context;
using SaleSystem.DAL.Interfaces;
using SaleSystem.DAL.Repositories;

namespace SaleSystem.IOC.Extensions
{
    public static class InjectionExtension
    {
        public static void AddDependenciesInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DBSALEContext>(
                options =>
                {
                    options.UseSqlServer(
                    configuration.GetConnectionString("SaleConnection"));
                });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ISaleRepository, SaleRepository>();
        }
    }
}
