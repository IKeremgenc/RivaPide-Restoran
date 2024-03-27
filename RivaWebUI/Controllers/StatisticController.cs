using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RivaWebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StatisticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
