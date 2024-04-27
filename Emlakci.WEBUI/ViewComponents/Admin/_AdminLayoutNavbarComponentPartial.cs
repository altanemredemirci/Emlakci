using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.ViewComponents.Admin
{
    public class _AdminLayoutNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}