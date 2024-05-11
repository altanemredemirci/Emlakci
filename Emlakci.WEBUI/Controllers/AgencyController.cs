using AutoMapper;
using Emlakci.BLL.Abstract;
using Emlakci.BLL.DTOs.AgencyDTO;
using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.Controllers
{
    public class AgencyController : Controller
    {
        private readonly IAgencyService _agencyService;
        private readonly IMapper _mapper;

        public AgencyController(IAgencyService agencyService, IMapper mapper)
        {
            _agencyService = agencyService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var agencies = _agencyService.GetAll();

            return View(_mapper.Map<List<ResultAgencyDTO>>(agencies));
        }
    }
}
