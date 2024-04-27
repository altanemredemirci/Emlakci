using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
