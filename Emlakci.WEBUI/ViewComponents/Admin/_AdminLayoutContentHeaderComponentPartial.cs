using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.ViewComponents.Admin
{
    public class _AdminLayoutContentHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}