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

        [HttpGet]
        public async Task<ActionResult> BuscarPorNome(string nome = "")
        {
            var lista = await _usuarioService.GetByName(string.Format("{0}/GetByName/{1}", APIChildren, nome));
            return Json(ConverterParaFormatoJson(lista));
        }

        [HttpGet]
        public async Task<ActionResult> BuscarTodos()
        {
            var lista = await _usuarioService.GetAll(string.Format("{0}/GetAll", APIChildren));
            return Json(ConverterParaFormatoJson(lista));
        }

    }
}
