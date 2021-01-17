using Microsoft.AspNetCore.Mvc;

namespace IWA.Challenge.Chat.View.Razor.Controllers
{
    public class SalaController : Controller
    {

        public SalaController()
        {

        }

        [HttpGet]

        public IActionResult Index(string userName)
        {
            return View("Index", userName);
        }


    }
}
