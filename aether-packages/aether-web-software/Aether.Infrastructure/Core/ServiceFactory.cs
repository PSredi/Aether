using Aether.Application.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aether.Infrastructure.Core
{
    /// <summary>
    /// Default implementation of the <see cref="Aether.Application.Core.IServiceFactory"/> interface
    /// </summary>
    public class ServiceFactory : IServiceFactory
    {
        private IServiceProvider _serviceCollection;

        /// <summary>
        /// Creates a new <see cref="Aether.Infrastructure.Core.ServiceFactory"/>
        /// </summary>
        /// <param name="serviceCollection">The application services</param>
        public ServiceFactory(IServiceProvider serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        public TService Get<TService>() =>
            _serviceCollection.GetService<TService>();
    }
}
