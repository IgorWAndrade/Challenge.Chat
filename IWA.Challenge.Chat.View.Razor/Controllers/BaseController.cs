using Microsoft.AspNetCore.Mvc;

namespace IWA.Challenge.Chat.View.Razor.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly string APIChildren = "";
        
        public BaseController(string serviceBase)
        {
            APIChildren = Startup.API + serviceBase;
        }

    }
}
