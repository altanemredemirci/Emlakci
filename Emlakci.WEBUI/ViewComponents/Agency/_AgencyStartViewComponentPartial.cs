using AutoMapper;
using Emlakci.BLL.Abstract;
using Emlakci.BLL.DTOs.AgencyDTO;
using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.ViewComponents.Agency
{
    public class _AgencyStartViewComponentPartial : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IAgencyService _agencyService;

        public _AgencyStartViewComponentPartial(IMapper mapper, IAgencyService agencyService)
        {
            _mapper = mapper;
            _agencyService = agencyService;
        }

        public IViewComponentResult Invoke()
        {
            var agencies = _agencyService.GetAll(i => i.Status == true);
            List<ResultAgencyDTO> resultAgencyModels = _mapper.Map<List<ResultAgencyDTO>>(agencies);

            return View(resultAgencyModels);
        }
    }
}
