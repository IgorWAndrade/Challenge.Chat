using IWA.Challenge.Chat.View.Razor.Services;
using IWA.Challenge.Chat.View.Razor.ViewModels;
using IWA.Challenge.Chat.View.Razor.ViewModels.Usuario;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IWA.Challenge.Chat.View.Razor.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService) : base("Usuario") 
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            return View("_Adicionar");
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(UsuarioPost usuarioPost)
        {
            UsuarioPost.Preparar(usuarioPost);
            return Json(await _usuarioService.Post(APIChildren, usuarioPost));
        }


    }
}
