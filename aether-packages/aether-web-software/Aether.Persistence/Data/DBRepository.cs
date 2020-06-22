using Aether.Application.Data.Repositories;
using Aether.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Aether.Persistence.Data
{
    /// <summary>
    /// An implementation of the <see cref="Aether.Application.Data.Repositories.IRepository{T}"/> interface that uses a backing database
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class DBRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private IDBContext _dbContext;
        private DbSet<TEntity> _dbSet;

        /// <summary>
        /// Creates a new instance of <see cref="Aether.Persistence.Data.DBRepository{TEntity}"/>
        /// </summary>
        /// <param name="dbContext">The backing databases database context</param>
        public DBRepository(IDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetEntities() => _dbSet;

        [return: NotNull]
        public TEntity Push([DisallowNull] TEntity entity)
        {
            entity = _dbSet.Add(entity).Entity;
            _dbContext.SaveChanges();
            return entity;
        }

        [return: NotNull]
        public TEntity Remove([DisallowNull] TEntity entity)
        {
            entity = _dbSet.Remove(entity).Entity;
            _dbContext.SaveChanges();
            return entity;
        }
    }
}
