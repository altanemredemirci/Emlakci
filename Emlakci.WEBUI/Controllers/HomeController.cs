using Emlakci.BLL.Abstract;
using Emlakci.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Emlakci.WEBUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;

        //Injection
        public HomeController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View(_categoryService.GetAll());
        }
    }
}
