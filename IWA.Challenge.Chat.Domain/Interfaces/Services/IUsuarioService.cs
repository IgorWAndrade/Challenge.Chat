using IWA.Challenge.Chat.Domain.Entities;

namespace IWA.Challenge.Chat.Domain.Interfaces.Services
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        bool ExisteNome(string nome);
    }
}
