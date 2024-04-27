using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.ViewComponents.Admin
{
    public class _AdminLayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
