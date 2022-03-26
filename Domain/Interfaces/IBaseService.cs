using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBaseService<T> where T : BaseEntity
    {
        T Add<TValidator> (T obj) where TValidator : AbstractValidator<T>;
        Task Delete(int id);
        IList<T> GetAll();
        T GetById(int id);
        T Update<TValidator>(T obj) where TValidator : AbstractValidator<T>;
    }
}
