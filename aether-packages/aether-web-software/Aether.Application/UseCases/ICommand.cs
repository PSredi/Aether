using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Aether.Application.UseCases
{
    /// <summary>
    /// Interface for a CQRS command
    /// </summary>
    /// <typeparam name="TCommandModel">The commands command model</typeparam>
    public interface ICommand<in TCommandModel> where TCommandModel : class
    {
        /// <summary>
        /// Executes the command
        /// </summary>
        /// <param name="commandModel">The command model</param>
        void Execute([DisallowNull] TCommandModel commandModel);
    }
}
