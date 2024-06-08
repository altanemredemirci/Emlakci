using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
