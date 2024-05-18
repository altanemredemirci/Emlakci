using Emlakci.BLL.Abstract;
using Emlakci.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.ViewComponents.Contact
{
    public class _AboutStartViewComponentPartial:ViewComponent
    {
        private readonly IEmploymentService _employmentService;
        private readonly IWhoWeAreService _whoWeAreService;

        public _AboutStartViewComponentPartial(IEmploymentService employmentService, IWhoWeAreService whoWeAreService)
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
