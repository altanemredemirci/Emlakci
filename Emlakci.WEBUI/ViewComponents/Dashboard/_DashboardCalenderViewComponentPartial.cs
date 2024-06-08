using Emlakci.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.ViewComponents.Dashboard
{
    public class _DashboardCalenderViewComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
