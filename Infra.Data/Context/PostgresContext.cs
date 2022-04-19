using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infra.Data.Mapping;

namespace Infra.Data.Context
{
    public class PostgresContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public PostgresContext(DbContextOptions<PostgresContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>(new UsersMap().Configure);
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.LogTo(x => System.Diagnostics.Debug.WriteLine(x));

    }
}
