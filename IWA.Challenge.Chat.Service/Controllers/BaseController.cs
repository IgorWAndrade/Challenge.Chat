using Microsoft.AspNetCore.Mvc;

namespace IWA.Challenge.Chat.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : Controller
    {
    }
}
