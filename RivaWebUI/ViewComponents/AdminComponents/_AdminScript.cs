using Microsoft.AspNetCore.Mvc;

namespace RivaWebUI.ViewComponents.AdminComponents
{
    public class _AdminScript : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
