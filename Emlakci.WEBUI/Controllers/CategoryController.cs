using AutoMapper;
using Emlakci.BLL.Abstract;
using Emlakci.BLL.DTOs.CategoryDTO;
using Emlakci.Entity;
using Emlakci.WEBUI.Mapping;
using Emlakci.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            //var models = new List<CategoryModel>();

            //foreach (var item in _categoryService.GetAll())
            //{
            //    models.Add(new CategoryModel()
            //    {
            //        Id = item.Id,
            //        Icon = item.Icon,
            //        Name = item.Name,
            //        Status = item.Status
            //    });
            //}

            List<ResultCategoryDTO> models = _mapper.Map<List<ResultCategoryDTO>>(_categoryService.GetAll());
            return View(models);
        }

        public ActionResult Create()
        {
            return View(new CreateCategoryDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(CreateCategoryDTO model, IFormFile file)
        {
            ModelState.Remove("Icon");
            if (ModelState.IsValid)
            {
                var cat = _categoryService.GetOne(i => i.Name == model.Name);

                if (cat != null)
                {
                    ModelState.AddModelError("", "Aynı isimde kategori kayıtlı");
                    return View(model);
                }

                if (file == null)
                {
                    ModelState.AddModelError("", "Kategori ikonu eklenmeli");
                    return View(model);
                }

                model.Icon=await ImageMethod.UploadImage(file);

                _categoryService.Create(_mapper.Map<Category>(model));
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var cat = _categoryService.GetById(id);
            if (cat != null)
            {                
                return View(_mapper.Map<UpdateCategoryDTO>(cat));
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateCategoryDTO model, IFormFile file)
        {
            ModelState.Remove("Icon");
            if (ModelState.IsValid)
            {
                var cat = _categoryService.GetById(model.Id);

                if (cat == null)
                {
                    return NotFound();
                }

                if (file != null)
                {
                    ImageMethod.DeleteImage(cat.Icon);
                    cat.Icon = await ImageMethod.UploadImage(file);
                }

                cat.Status = model.Status;
                cat.Name = model.Name;

                _categoryService.Update(cat);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var cat = _categoryService.GetById(id);
            if (cat != null)
            {
                _categoryService.Delete(cat);

                ImageMethod.DeleteImage(cat.Icon);
               
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
