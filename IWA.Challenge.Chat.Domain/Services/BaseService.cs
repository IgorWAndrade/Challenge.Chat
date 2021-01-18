using IWA.Challenge.Chat.Domain.Entities;
using IWA.Challenge.Chat.Domain.Interfaces.Repositories;
using IWA.Challenge.Chat.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IWA.Challenge.Chat.Domain.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected readonly IBaseRepository<T> _repositorio;

        public BaseService(IBaseRepository<T> repositorio)
        {
            _repositorio = repositorio;
        }
        public async Task<int> Add(T entidade)
        {
            return await _repositorio.Add(entidade);
        }

        public async Task<T> Update(T entidade)
        {
            return await _repositorio.Update(entidade);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repositorio.Delete(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _repositorio.GetAll();
        }

        public async Task<IEnumerable<T>> GetAllExpression(Expression<Func<T, bool>> expression)
        {
            return await _repositorio.GetAllExpression(expression);
        }

        public async Task<T> GetById(int id)
        {
            return await _repositorio.GetById(id);
        }

        public IQueryable<T> QueriableExpression(Expression<Func<T, bool>> expression)
        {
            return _repositorio.QueriableExpression(expression);
        }
    }
}
