using Microsoft.AspNetCore.Mvc;

namespace RivaWebUI.ViewComponents.UIComponents
{
    public class _UIHeader:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
