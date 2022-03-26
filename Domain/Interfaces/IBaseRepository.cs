using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> Insert(T obj);
        Task<T> Update(T obj);
        Task Delete(int id);
        IList<T> GetAll();
        T Get(int id);
    }
}
