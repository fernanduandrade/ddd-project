using Domain.Entities;
using FluentValidation;

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
