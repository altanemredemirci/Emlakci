using Emlakci.BLL.Abstract;
using Emlakci.Entity;
using Emlakci.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var models = new List<CategoryModel>();

            foreach (var item in _categoryService.GetAll())
            {
                models.Add(new CategoryModel()
                {
                    Id = item.Id,
                    Icon = item.Icon,
                    Name = item.Name,
                    Status = item.Status
                });
            }
            return View(models);
        }

        public ActionResult Create()
        {
            return View(new CategoryModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(CategoryModel model, IFormFile file)
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

                UploadImage(file);

                _categoryService.Create(new Category()
                {
                    Name = model.Name,
                    Icon = file.FileName,
                    Status = model.Status
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var cat = _categoryService.GetById(id);
            if (cat != null)
            {                
                return View(new CategoryModel()
                {
                    Id = cat.Id,
                    Icon = cat.Icon,
                    Name = cat.Name,
                    Status = cat.Status
                });
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryModel model, IFormFile file)
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
                    DeleteImage(cat.Icon);
                    cat.Icon = file.FileName;
                    UploadImage(file);
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

                DeleteImage(cat.Icon);
               
                return RedirectToAction("Index");
            }
            return View();
        }


        private void DeleteImage(string fileName)
        {
            var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\RealEstate\\img", fileName);

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
        }

        private async void UploadImage(IFormFile file)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\RealEstate\\img", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }
    }
}
