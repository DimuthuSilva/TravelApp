using Microsoft.Extensions.DependencyInjection;
using TravelApp.Application.Contracts.Persistance;
using TravelApp.Persistence.Repositories;

namespace TravelApp.Persistence
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services)
        {
            //register repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ITransportTypeRepository, TransportTypeRepository>();

            return services;
        }
    }
}
