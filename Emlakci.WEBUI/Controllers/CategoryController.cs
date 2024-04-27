using Emlakci.BLL.Abstract;
using Emlakci.Entity;
using Emlakci.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var models = new List<CategoryModel>();

            foreach (var item in _categoryService.GetAll())
            {
                models.Add(new CategoryModel()
                {
                    Id = item.Id,
                    Icon = item.Icon,
                    Name = item.Name,
                    Status = item.Status
                });
            }
            return View(models);
        }
    }
}
