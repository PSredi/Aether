using Aether.Application.Services.User;
using Aether.Application.UseCases.User;
using Aether.Application.UseCases.User.Implementation.AuthenticateUserCommand;
using Aether.Application.UseCases.User.Implementation.RegisterUserCommand;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aether.Application.Helpers
{
    /// <summary>
    /// Helper that registers application services inside a service collection
    /// </summary>
    public static class ApplicationServiceHelper
    {
        /// <summary>
        /// Adds application services to the <paramref name="services"/> service collection
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <returns>The service collection</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticateUserCommand, AuthenticateUserCommand>();
            services.AddTransient<IRegisterUserCommand, RegisterUserCommand>();
            services.AddScoped<IUserSessionService, EmptyUserSessionService>();
            return services;
        }

    }
}
