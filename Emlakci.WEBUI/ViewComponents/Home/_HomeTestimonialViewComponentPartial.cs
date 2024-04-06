using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.ViewComponents.Home
{
    public class _HomeTestimonialViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}