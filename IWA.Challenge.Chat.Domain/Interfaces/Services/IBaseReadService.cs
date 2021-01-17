using IWA.Challenge.Chat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IWA.Challenge.Chat.Domain.Interfaces.Services
{
    public interface IBaseReadService<T> where T : BaseEntity
    {
        Task<T> GetById(int id);

        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> GetAllExpression(Expression<Func<T, bool>> expression);
    }
}
