using Microsoft.AspNetCore.Mvc;

namespace IWA.Challenge.Chat.View.Razor.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
