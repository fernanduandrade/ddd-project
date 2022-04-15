using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly PostgresContext _postgresContext;
        public BaseRepository(PostgresContext postgresContext)
        {
            _postgresContext = postgresContext;
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
            var current = await _postgresContext.Set<T>().SingleOrDefaultAsync(x => x.id == obj.id);
            if (current == null)
                return null;

            _postgresContext.Entry(current).CurrentValues.SetValues(obj);
            await _postgresContext.SaveChangesAsync();
            return obj;
        }

        public async Task Delete(int id)
        {
            _postgresContext.Set<T>().Remove(Get(id));
            _postgresContext.SaveChanges();
        }

        public IList<T> GetAll() => _postgresContext.Set<T>().ToList();

        public T Get(int id) => _postgresContext.Set<T>().Find(id);
    }
}
