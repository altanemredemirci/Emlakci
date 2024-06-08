using Emlakci.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IStatisticService _statisticService;

        public StatisticController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        public IActionResult Index()
        {
            ViewBag.CategoryCount = _statisticService.CategoryCount();
            ViewBag.ActiveCategoryCount = _statisticService.ActiveCategoryCount();
            ViewBag.PassiveCategoryCount = _statisticService.PassiveCategoryCount();
            ViewBag.ProductCount = _statisticService.ProductCount();
            ViewBag.TopAgencyByProductCount = _statisticService.TopAgencyByProductCount();
            ViewBag.TopCategoryByProductCount = _statisticService.TopCategoryByProductCount();
            ViewBag.AvgProductBySale = _statisticService.AvgProductBySale();
            ViewBag.AvgProductByRent = _statisticService.AvgProductByRent();
            ViewBag.TopCityByProductCount = _statisticService.TopCityByProductCount();
            ViewBag.DiffrentCityCount = _statisticService.DiffrentCityCount();
            ViewBag.LastProductPrice = _statisticService.LastProductPrice();
            ViewBag.NewestBuilderYear = _statisticService.NewestBuilderYear();
            ViewBag.OldestBuilderYear = _statisticService.OldestBuilderYear();
            ViewBag.ActiveAgencyCount = _statisticService.ActiveAgencyCount();
            ViewBag.DaireCount = _statisticService.DaireCount();
            ViewBag.AvgRoomCount = _statisticService.AvgRoomCount();

            return View();
        }
    }
}
