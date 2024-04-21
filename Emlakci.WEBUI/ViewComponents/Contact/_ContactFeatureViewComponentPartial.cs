using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.ViewComponents.Contact
{
    public class _ContactFeatureViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}