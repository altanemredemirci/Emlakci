using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.ViewComponents.Contact
{
    public class _ContactStartViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
