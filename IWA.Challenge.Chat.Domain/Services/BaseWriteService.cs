using IWA.Challenge.Chat.Domain.Entities;
using IWA.Challenge.Chat.Domain.Interfaces.Repositories;
using IWA.Challenge.Chat.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace IWA.Challenge.Chat.Domain.Services
{
    public class BaseWriteService<T> : IBaseWriteService<T> where T : BaseEntity
    {
        protected readonly IBaseWriteRepository<T> _repositorio;

        public BaseWriteService(IBaseWriteRepository<T> repositorio)
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
    }
}
