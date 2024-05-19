using AutoMapper;
using Emlakci.BLL.Abstract;
using Emlakci.BLL.DTOs.SliderDTO;
using Emlakci.Entity;
using Emlakci.WEBUI.Mapping;
using Emlakci.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.Controllers
{
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var sliderService = _sliderService.GetAll();
            return View(_mapper.Map<List<ResultSliderDTO>>(sliderService));
        }

        public IActionResult Create()
        {
            return View(new CreateSliderDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSliderDTO dto, IFormFile file1, IFormFile file2)
        {
            ModelState.Remove("ImageUrl1");
            ModelState.Remove("file2");
            if (ModelState.IsValid)
            {
                if (file1 == null)
                {
                    ErrorViewModel error = new ErrorViewModel()
                    {
                        Title = "Resim Hatası",
                        Message = "1. resim yüklenmedi.",
                        ReturnUrl = "/Slider/Index"
                    };
                }

                dto.ImageUrl1 = await ImageMethod.UploadImage(file1);

                if (file2 !=null)
                {
                    dto.ImageUrl2 = await ImageMethod.UploadImage(file2);
                }

                _sliderService.Create(_mapper.Map<Slider>(dto));

                return RedirectToAction("Index");

            }


            return View(dto);
        }

    }
}
