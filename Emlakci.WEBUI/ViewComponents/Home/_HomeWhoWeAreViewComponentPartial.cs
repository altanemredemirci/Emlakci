using Emlakci.BLL.Abstract;
using Emlakci.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Emlakci.WEBUI.ViewComponents.Home
{
    public class _HomeWhoWeAreViewComponentPartial : ViewComponent
    {
        private readonly IEmploymentService _employmentService;
        private readonly IWhoWeAreService _whoWeAreService;

        public _HomeWhoWeAreViewComponentPartial(IEmploymentService employmentService,IWhoWeAreService whoWeAreService)
        {
            _employmentService = employmentService;
            _whoWeAreService = whoWeAreService;
        }

        public IViewComponentResult Invoke()
        {
            var whoWeAre = _whoWeAreService.GetAll().FirstOrDefault();

            ViewBag.Title = whoWeAre.Title;
            ViewBag.Description = whoWeAre.Description;


            return View(_employmentService.GetAll().Where(i => i.Status == true).Select(i => new ResultEmploymentModel()
            {
                Name = i.Name,
                Status = i.Status,
                Id = i.Id
            }).ToList());
        }
    }
}