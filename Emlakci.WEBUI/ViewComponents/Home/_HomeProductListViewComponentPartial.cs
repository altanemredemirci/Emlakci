using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.ViewComponents.Home
{
    public class _HomeProductListViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
