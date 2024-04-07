using Emlakci.BLL.Abstract;
using Emlakci.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.ViewComponents.Home
{
    public class _HomeProductListViewComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _HomeProductListViewComponentPartial(IProductService productService)
        {
            _productService = productService;
        }
        public IViewComponentResult Invoke()
        {
            List<ResultProductModel> resultProductModels = new List<ResultProductModel>();

            foreach (var item in _productService.GetAll())
            {
                resultProductModels.Add(new ResultProductModel()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Price = item.Price,
                    City = item.City,
                    District = item.District,
                    Address = item.Address,
                    CategoryName = item.Category.Name,
                    CoverImage = item.CoverImage,
                    Type=item.Type
                });
            }

            return View(resultProductModels);
        }
    }
}
