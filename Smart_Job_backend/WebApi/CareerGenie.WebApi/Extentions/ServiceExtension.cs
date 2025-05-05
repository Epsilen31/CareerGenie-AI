using CareerGenie.DataAccess;
using CareerGenie.DataAccess.Contracts;

namespace CareerGenie.WebApi
{
    public static class ServiceExtensions
    {
        public static void GetServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
