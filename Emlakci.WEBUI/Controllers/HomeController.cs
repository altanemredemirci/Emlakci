using Emlakci.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Emlakci.WEBUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
