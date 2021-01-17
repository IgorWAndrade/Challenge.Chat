using IWA.Challenge.Chat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IWA.Challenge.Chat.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<int> Add(T entidade);

        Task<T> Update(T entidade);

        Task<bool> Delete(int id);

        Task<T> GetById(int id);

        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> GetAllExpression(Expression<Func<T, bool>> expression);
    }
}
