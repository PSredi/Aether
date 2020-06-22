using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Aether.Application.Data.Repositories
{
    /// <summary>
    /// Interface for repositories.
    /// </summary>
    /// <typeparam name="T">The type which the repository should store</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Returns a sequence of entities that currently are stored in the repository.
        /// </summary>
        /// <returns>A sequence of tracked entities</returns>
        IEnumerable<T> GetEntities();

        /// <summary>
        /// Pushes a new entity into the repository. If the repository already contains the entity the values are updated.
        /// </summary>
        /// <param name="entity">The entity to push</param>
        /// <returns>The tracked entity</returns>
        [return: NotNull]
        T Push([DisallowNull] T entity);

        /// <summary>
        /// Removes an entity from the repository
        /// </summary>
        /// <param name="entity">The entity to remove</param>
        /// <returns>The tracked entity</returns>
        /// <exception cref="ArgumentException">Throws when the repository does not contain the entity</exception>
        [return: NotNull]
        T Remove([DisallowNull] T entity);
    }
}
