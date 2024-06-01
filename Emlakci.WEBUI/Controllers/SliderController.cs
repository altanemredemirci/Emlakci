using AutoMapper;
using Emlakci.BLL.Abstract;
using Emlakci.BLL.DTOs.SliderDTO;
using Emlakci.Entity;
using Emlakci.WEBUI.Mapping;
using Emlakci.WEBUI.Models;
using Humanizer;
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

        public IActionResult Edit(int id)
        {
            var slider = _sliderService.GetById(id);

            return View(_mapper.Map<UpdateSliderDTO>(slider));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateSliderDTO dto, IFormFile file1, IFormFile file2)
        {
            ModelState.Remove("file1");
            ModelState.Remove("file2");
            if (ModelState.IsValid)
            {
                var slider = _sliderService.GetById(dto.Id);

                if (slider == null)
                {
                    ErrorViewModel error = new ErrorViewModel()
                    {
                        Title = "Slider Bulunamadı",
                        Message = "Lütfen seçtiğiniz yapıyı tekrar kontrol ediniz.",
                        ReturnUrl = "/Slider/Index"
                    };
                    return View("Error", error);
                }

                if (file1 != null)
                {
                    if (slider.ImageUrl1 != null)
                    {
                        ImageMethod.DeleteImage(slider.ImageUrl1);
                    }
                    dto.ImageUrl1 = await ImageMethod.UploadImage(file1);
                }
                if (file2 != null)
                {
                    if (slider.ImageUrl2 != null)
                    {
                        ImageMethod.DeleteImage(slider.ImageUrl2);
                    }
                    dto.ImageUrl2 = await ImageMethod.UploadImage(file2);
                }

                _sliderService.Update(_mapper.Map<Slider>(dto));
                return RedirectToAction("Index");
            }
            return View(dto);
        }

        public JsonResult ImageRemove(int id, int no)
        {
            var slider = _sliderService.GetById(id);
            if (no == 1)
            {
                ImageMethod.DeleteImage(slider.ImageUrl1);
                slider.ImageUrl1 = null;
            }
            else
            {
                ImageMethod.DeleteImage(slider.ImageUrl2);
                slider.ImageUrl2 = null;
            }
            _sliderService.Update(slider);
            return Json(new { data = slider });
        }
    }
}
