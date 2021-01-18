using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace IWA.Challenge.Chat.Infra.Data.Interfaces
{
    interface IBaseContexto
    {
        Task<IDbContextTransaction> StartTransaction();
        Task RollBack();
        Task Commit();
    }
}
