using Microsoft.AspNetCore.Mvc;

namespace RivaWebUI.ViewComponents.UIComponents
{
    public class _UIScript:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
