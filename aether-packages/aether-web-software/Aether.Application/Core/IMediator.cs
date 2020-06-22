using Aether.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;

namespace Aether.Application.Core
{
    /// <summary>
    /// Interface for a CQRS mediator
    /// </summary>
    public interface IMediator
    {
        /// <summary>
        /// Posts a command
        /// </summary>
        /// <typeparam name="TCommand">The command type</typeparam>
        /// <typeparam name="TCommandModel">The command model type</typeparam>
        /// <param name="commandModel">The command model</param>
        void Send<TCommand, TCommandModel>([DisallowNull] TCommandModel commandModel) where TCommand : ICommand<TCommandModel> where TCommandModel : class;
        
        /// <summary>
        /// Sends a query
        /// </summary>
        /// <typeparam name="TQuery">The query type</typeparam>
        /// <typeparam name="TResponseModel">The response model type</typeparam>
        /// <returns>The response</returns>
        [return: NotNull]
        TResponseModel Send<TQuery, TResponseModel>() where TQuery : IQuery<TResponseModel> where TResponseModel : class;
    }
}
