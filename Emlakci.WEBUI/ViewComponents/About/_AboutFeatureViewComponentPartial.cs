using AutoMapper;
using Emlakci.BLL.Abstract;
using Emlakci.BLL.DTOs.SliderDTO;
using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.ViewComponents.Contact
{
    public class _AboutFeatureViewComponentPartial : ViewComponent
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public _AboutFeatureViewComponentPartial(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            return View(_mapper.Map<ResultSliderDTO>(_sliderService.GetOne(i=> i.Page=="About")));
        }
    }
}