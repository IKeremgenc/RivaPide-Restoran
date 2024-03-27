using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RivaWebUI.Controllers
{
    [AllowAnonymous]
    public class TestController : Controller
    {
        public IActionResult Sepet()
        {
            return View();
        }
    }
}
