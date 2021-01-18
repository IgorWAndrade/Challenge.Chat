using IWA.Challenge.Chat.Domain.Entities;
using IWA.Challenge.Chat.Domain.Interfaces.Repositories;
using IWA.Challenge.Chat.Domain.Interfaces.Services;
using System.Linq;

namespace IWA.Challenge.Chat.Domain.Services
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {

        public UsuarioService(IUsuarioRepository repository) : base(repository)
        {
        }

        public bool ExisteNome(string nome)
        {
            return QueriableExpression(x => x.Nome.Equals(nome)).Any();
        }
    }
}
