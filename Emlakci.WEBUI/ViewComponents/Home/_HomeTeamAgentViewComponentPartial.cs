using Emlakci.BLL.Abstract;
using Emlakci.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.ViewComponents.Home
{
    public class _HomeTeamAgentViewComponentPartial : ViewComponent
    {
        private readonly IAgencyService _agencyService;

        public _HomeTeamAgentViewComponentPartial(IAgencyService agencyService)
        {
            _agencyService = agencyService;
        }
        public IViewComponentResult Invoke()
        {
            List<ResultAgencyModel> resultAgencyModels = new List<ResultAgencyModel>();

            foreach (var item in _agencyService.GetAll())
            {
                resultAgencyModels.Add(new ResultAgencyModel()
                {
                    FullName = item.FullName,
                    Title = item.Title,
                    Image = item.Image,
                    SocialOne = item.SocialOne,
                    SocialTwo = item.SocialTwo,
                    SocialThree = item.SocialThree
                });
            }

            return View(resultAgencyModels);
        }
    }
}