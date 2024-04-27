using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.ViewComponents.Admin
{
    public class _AdminLayoutSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}