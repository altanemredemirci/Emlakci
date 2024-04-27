using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.ViewComponents.Admin
{
    public class _AdminLayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
