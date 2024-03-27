using Microsoft.AspNetCore.Mvc;

namespace RivaWebUI.ViewComponents.AdminComponents
{
    public class _AdminHeader : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
