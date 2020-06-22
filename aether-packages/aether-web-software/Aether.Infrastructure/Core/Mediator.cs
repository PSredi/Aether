using Aether.Application.Core;
using Aether.Application.Core.Exceptions;
using Aether.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;

namespace Aether.Infrastructure.Core
{
    /// <summary>
    /// Default implementation of the <see cref="Aether.Application.Core.IMediator"/> interface
    /// </summary>
    public class Mediator : IMediator
    {
        private IServiceFactory _serviceFactory;

        /// <summary>
        /// Creates a new instance of <see cref="Aether.Infrastructure.Core.Mediator"/>
        /// </summary>
        /// <param name="serviceFactory">The applications service factory</param>
        public Mediator(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        public void Send<TCommand, TCommandModel>([DisallowNull] TCommandModel commandModel)
            where TCommand : ICommand<TCommandModel>
            where TCommandModel : class
        {
            var command = _serviceFactory.Get<TCommand>() ?? throw new MediatorMissingRequestImplementationException();
            command.Execute(commandModel);
        }

        [return: NotNull]
        public TResponseModel Send<TQuery, TResponseModel>()
            where TQuery : IQuery<TResponseModel>
            where TResponseModel : class
        {
            var query = _serviceFactory.Get<TQuery>() ?? throw new MediatorMissingRequestImplementationException();
            return query.Process();
        }
    }
}
