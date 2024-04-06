using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.ViewComponents.Layout
{
    public class _ScriptViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}