using Microsoft.AspNetCore.Mvc;

namespace RivaWebUI.ViewComponents.AdminComponents
{
    public class _AdminSideBar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
