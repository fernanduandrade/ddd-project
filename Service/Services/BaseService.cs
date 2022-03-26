using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _baseRepository;
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public T Add<TValidator>(T obj) where TValidator : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Insert(obj);
            return obj;
        }

        public Task Delete(int id) => _baseRepository.Delete(id);

        public IList<T> GetAll() => _baseRepository.GetAll();

        public T GetById(int id) => _baseRepository.Get(id);

        public T Update<TValidator>(T obj) where TValidator : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Update(obj);
            return obj;
        } 

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectado");

            validator.ValidateAndThrow(obj);
        }


    }
}
