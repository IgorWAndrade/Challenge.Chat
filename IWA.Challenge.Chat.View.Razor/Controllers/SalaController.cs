using IWA.Challenge.Chat.View.Razor.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IWA.Challenge.Chat.View.Razor.Controllers
{
    public class SalaController : BaseController
    {
        private readonly UsuarioService _usuarioService;

        public SalaController(UsuarioService usuarioService) : base("Sala")
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var usuario = await _usuarioService.GetById(Startup.API + "Usuario/" + id);
            return View("Index", usuario);
        }


    }
}
