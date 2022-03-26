using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infra.Data.Mapping;

namespace Infra.Data.Context
{
    public class PostgresContext : DbContext
    {
        public PostgresContext(DbContextOptions<PostgresContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<User>(new UserMap().Configure);
        //}

    }
}
