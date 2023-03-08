using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaleSystem.BLL.Interfaces;
using SaleSystem.BLL.Services;
using SaleSystem.DAL.Context;
using SaleSystem.DAL.Interfaces;
using SaleSystem.DAL.Repositories;
using System.Reflection;

namespace SaleSystem.IOC.Extensions
{
    public static class InjectionExtension
    {
        public static void AddDependenciesInjection(this IServiceCollection services, IConfiguration configuration)
        {
            var path = System.Reflection.Assembly.GetExecutingAssembly().Location;

            services.AddDbContext<DBSALEContext>(
                options =>
                {
                    options.UseSqlServer(
                    configuration.GetConnectionString("SaleConnection"));
                });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddAutoMapper(Assembly.Load("SaleSystem.Utilities"));
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IDashBoardService, DashBoardService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
