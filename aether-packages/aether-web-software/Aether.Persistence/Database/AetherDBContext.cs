using Aether.Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aether.Persistence.Database
{
    public class AetherDBContext : DbContext, IDBContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<AuthenticationProvider> AuthenticationProviders { get; set; }

        public AetherDBContext(DbContextOptions<AetherDBContext> options) : base(options) { }

        void IDBContext.SaveChanges()
        {
            SaveChanges();
        }
    }
}
