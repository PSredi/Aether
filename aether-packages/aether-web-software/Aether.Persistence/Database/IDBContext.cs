using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aether.Persistence.Database
{
    /// <summary>
    /// Interface for a db context implementation
    /// </summary>
    public interface IDBContext
    {
        /// <summary>
        /// Saves changes to the backing database
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Returns the <see cref="Microsoft.EntityFrameworkCore.DbSet{TEntity}"/> entry for the specified entity type
        /// </summary>
        /// <typeparam name="TEntity">The entity type</typeparam>
        /// <returns>The <see cref="Microsoft.EntityFrameworkCore.DbSet{TEntity}"/> entry</returns>
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
