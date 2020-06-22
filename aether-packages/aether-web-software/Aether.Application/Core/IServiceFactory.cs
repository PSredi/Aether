using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Aether.Application.Core
{
    /// <summary>
    /// Factory for application services
    /// </summary>
    public interface IServiceFactory
    {
        /// <summary>
        /// Gets the requested service
        /// </summary>
        /// <typeparam name="TService">The service type</typeparam>
        /// <returns>The service instance</returns>
        [return: MaybeNull]
        public TService Get<TService>();
    }
}
