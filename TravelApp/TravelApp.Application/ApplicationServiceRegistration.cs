using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TravelApp.Application
{
    public static class ApplicationServiceRegistration
    {
        /// <summary>
        /// Adds the application services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //register mediatr
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //register automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
