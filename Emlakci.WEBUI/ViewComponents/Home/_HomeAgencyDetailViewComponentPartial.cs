using AutoMapper;
using Emlakci.BLL.Abstract;
using Emlakci.BLL.DTOs.AgencyDTO;
using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.ViewComponents.Home
{
    public class _HomeAgencyDetailViewComponentPartial:ViewComponent
    {
        private readonly IAgencyService _agencyService;
        private readonly IMapper _mapper;

        public _HomeAgencyDetailViewComponentPartial(IAgencyService agencyService, IMapper mapper)
        {
            _agencyService = agencyService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke(int id)
        {
            var agency = _agencyService.GetById(id);
            return View(_mapper.Map<ResultAgencyDTO>(agency));
        }
    }
}
