using IWA.Challenge.Chat.Domain.Entities;
using IWA.Challenge.Chat.Domain.Interfaces.Repositories;
using IWA.Challenge.Chat.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IWA.Challenge.Chat.Infra.Data.Repositories
{
    public class BaseRepository<T> :
        IBaseRepository<T> where T : BaseEntity
    {
        protected readonly BaseContexto _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(BaseContexto context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<int> Add(T entidade)
        {
            try
            {
                await _context.StartTransaction();
                var obj = await _dbSet.AddAsync(entidade);
                await _context.Commit();
                return obj.Entity.Id;
            }
            catch
            {
                return entidade.Id;
            }
        }

        public async Task<T> Update(T entidade)
        {
            try
            {
                await _context.StartTransaction();
                _dbSet.Attach(entidade);
                _context.Entry(entidade).State = EntityState.Modified;
                await _context.Commit();
                return entidade;
            }
            catch
            {
                return entidade;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var entidade = await GetById(id);
                if (entidade != null)
                {
                    await _context.StartTransaction();
                    _dbSet.Remove(entidade);
                    await _context.Commit();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllExpression(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AsNoTracking().Where(expression).ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
