using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RivaWebUI.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CLientUserCount()
        {
            return View();
        }
    }
}
