using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Emlakci.DAL.Concrete.EfCore;
using Emlakci.Entity;
using Emlakci.BLL.Abstract;
using AutoMapper;
using Emlakci.BLL.DTOs.WhoWeAreDTO;
using Emlakci.WEBUI.Models;
using Emlakci.WEBUI.Mapping;

namespace Emlakci.WEBUI.Controllers
{
    public class WhoWeAreController : Controller
    {
        private readonly IWhoWeAreService _whoWeAreService;
        private readonly IMapper _mapper;

        public WhoWeAreController(IWhoWeAreService whoWeAreService,IMapper mapper)
        {
            _whoWeAreService = whoWeAreService;
            _mapper = mapper;
        }

        // GET: WhoWeAre
        public IActionResult Index()
        {
            var about = _whoWeAreService.GetFirst();
            return View(_mapper.Map<ResultWhoWeAreDTO>(about));
        }

        // GET: WhoWeAre/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                ErrorViewModel error = new ErrorViewModel()
                {
                    Title = "NOT FOUND",
                    Message = "Do not found searched",
                    ReturnUrl = "/WhoWeAre/Index"
                };
            }

            var whoWeAre = _whoWeAreService.GetById(id.Value); 
            if (whoWeAre == null)
            {
                ErrorViewModel error = new ErrorViewModel()
                {
                    Title = "NOT FOUND",
                    Message = "Do not found searched",
                    ReturnUrl = "/WhoWeAre/Index"
                };
            }
            return View(_mapper.Map<UpdateWhoWeAreDTO>(whoWeAre));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateWhoWeAreDTO dto, IFormFile file)
        {

            if (ModelState.IsValid)
            {
                var whoweare = _whoWeAreService.GetById(dto.Id);
                if (file != null)
                {
                    ImageMethod.DeleteImage(whoweare.ImageUrl);

                   dto.ImageUrl = await ImageMethod.UploadImage(file);
                }

                _whoWeAreService.Update(_mapper.Map<WhoWeAre>(dto));

                return RedirectToAction("Index");
            }

            return View(dto);
        }
     
    }
}
