using System.Reflection;
using CareerGenie.Context;
using CareerGenie.Core.Settings;
using CareerGenie.Services.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CareerGenie.WebApi
{
    public static class Startup
    {
        public static void ConfigureServices(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddControllers();
            services.GetServices();

            services.Configure<AppSetting>(configuration.GetSection("AppSetting"));
            services.AddSingleton(resolver =>
                resolver.GetRequiredService<IOptions<AppSetting>>().Value
            );

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DatabaseContext>(options =>
                options.UseMySql(
                    connectionString,
                    new MySqlServerVersion(new Version(8, 0, 23)),
                    b => b.MigrationsAssembly("CareerGenie.WebApi")
                )
            );

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(
                    Assembly.GetExecutingAssembly(),
                    typeof(IMediatorService).Assembly
                )
            );
        }
    }
}
