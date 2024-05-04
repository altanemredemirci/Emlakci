using Emlakci.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<IActionResult> GetDistricts(int cityId)
        {
            var districts = _cityService.GetAll(i => i.Id == cityId).FirstOrDefault().Districts.Select(d => new { Id = d.Id, Name = d.Name });
            return Json(districts);

        }
    }
}
