using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly PostgresContext _postgresContext;
        protected readonly PostgresContext Db;
        protected readonly DbSet<T> DbSet;
        public BaseRepository(PostgresContext postgresContext)
        {
            _postgresContext = postgresContext;
            Db = postgresContext;
            DbSet = Db.Set<T>();
        }

        public async Task<T> Insert(T obj)
        {
            var entity = obj;
            _postgresContext.Set<T>().Add(entity);
            await _postgresContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T obj)
        {
            var current = await DbSet.SingleOrDefaultAsync(x => x.Id == obj.Id);
            if (current == null)
                return null;
            var dbEntry = Db.ChangeTracker.Entries<BaseEntity>()
                .FirstOrDefault(x => x.Entity.Id == current.Id);
            if (dbEntry == null)
            {
                dbEntry = Db.Entry<BaseEntity>(current);
            }
            dbEntry.CurrentValues.SetValues(obj);
            dbEntry.State = EntityState.Modified;
            await Db.SaveChangesAsync();
            return obj;
            // _postgresContext.Entry(current).CurrentValues.SetValues(obj);
            // await _postgresContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _postgresContext.Set<T>().Remove(Get(id));
            await _postgresContext.SaveChangesAsync();
        }

        public IList<T> GetAll() => _postgresContext.Set<T>().ToList();

        public T Get(int id) => _postgresContext.Set<T>().Find(id);

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
