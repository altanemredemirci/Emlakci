using AutoMapper;
using Emlakci.BLL.Abstract;
using Emlakci.BLL.DTOs.AgencyDTO;
using Emlakci.Entity;
using Emlakci.WEBUI.Mapping;
using Emlakci.WEBUI.Models;
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

        public IActionResult Create()
        {
            return View(new CreateAgencyDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAgencyDTO model,IFormFile file)
        {
            ModelState.Remove("file");
            ModelState.Remove("Image");
            if (ModelState.IsValid)
            {

                var ag = _agencyService.GetAll(i => i.FullName == model.FullName).FirstOrDefault();

                if (ag != null)
                {
                    ModelState.AddModelError("", "Aynı isimde acenta kayıtlı");
                    return View(model);
                }

                if (file == null)
                {
                    ModelState.AddModelError("", "Resim yüklenmedi");
                    return View(model);
                }

                model.Image = await ImageMethod.UploadImage(file);

                var agency = _mapper.Map<Agency>(model);
                _agencyService.Create(agency);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = _agencyService.GetById(id);

            if (model == null)
            {
                ErrorViewModel error = new ErrorViewModel()
                {
                    Title = "NOT FOUND",
                    Message = "Acenta bulunamadı",
                    ReturnUrl = "/Agency/Index"
                };

                return View("Error", error);
            }

            var agencyModel = _mapper.Map<UpdateAgencyDTO>(model);

            return View(agencyModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateAgencyDTO model,IFormFile file)
        {
            ModelState.Remove("file");
            if (ModelState.IsValid)
            {  
                if (file != null)
                {
                    ImageMethod.DeleteImage(model.Image);
                    model.Image = await ImageMethod.UploadImage(file);
                }

                var agency = _mapper.Map<Agency>(model);

                _agencyService.Update(agency);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var agency = _agencyService.GetById(id);

            _agencyService.Delete(agency);
            ImageMethod.DeleteImage(agency.Image);

            return RedirectToAction("Index");
        }
    }
}
