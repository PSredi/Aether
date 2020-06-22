using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Aether.Application.UseCases
{
    /// <summary>
    /// Interface for a CQRS query
    /// </summary>
    /// <typeparam name="TResponseModel">The type of the queries response model</typeparam>
    public interface IQuery<out TResponseModel> where TResponseModel : class
    {
        /// <summary>
        /// Processes the query and returns it's result
        /// </summary>
        /// <returns>The result</returns>
        [return: NotNull]
        TResponseModel Process();
    }
}
