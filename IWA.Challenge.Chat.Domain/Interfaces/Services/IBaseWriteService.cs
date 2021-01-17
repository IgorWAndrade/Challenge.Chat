using IWA.Challenge.Chat.Domain.Entities;
using System.Threading.Tasks;

namespace IWA.Challenge.Chat.Domain.Interfaces.Services
{
    public interface IBaseWriteService<T> where T : BaseEntity
    {
        Task<int> Add(T entidade);

        Task<T> Update(T entidade);

        Task<bool> Delete(int id);
    }
}
