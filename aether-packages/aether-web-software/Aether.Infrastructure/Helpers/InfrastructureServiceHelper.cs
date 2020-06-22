using Aether.Application.Core;
using Aether.Infrastructure.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aether.Infrastructure.Helpers
{
    /// <summary>
    /// Helper that registers infrastructure services inside a service collection
    /// </summary>
    public static class InfrastructureServiceHelper
    {
        /// <summary>
        /// Adds infrastructure services to the <paramref name="services"/> service collection
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <returns>The service collection</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IMediator, Mediator>();
            services.AddScoped<IServiceFactory, ServiceFactory>();
            return services;
        }

    }
}
