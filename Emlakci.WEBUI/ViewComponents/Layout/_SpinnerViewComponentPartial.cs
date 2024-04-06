using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.ViewComponents.Layout
{
    public class _SpinnerViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}