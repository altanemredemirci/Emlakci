using Emlakci.BLL.Abstract;
using Emlakci.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.ViewComponents.Home
{
    public class _HomeProductTypeViewComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _HomeProductTypeViewComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            List<ResultProductTypeModel> resultProductTypeModels = new List<ResultProductTypeModel>();

            foreach (var item in _categoryService.GetAll())
            {
                if (item.Status)
                {
                    resultProductTypeModels.Add(new ResultProductTypeModel()
                    {
                        Name = item.Name,
                        Status = item.Status,
                        Icon = item.Icon,
                        Products = item.Products
                    });
                }
               
            }

            return View(resultProductTypeModels);
        }
    }
}
