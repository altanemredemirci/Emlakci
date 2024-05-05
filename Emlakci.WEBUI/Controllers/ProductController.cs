using AutoMapper;
using Emlakci.BLL.Abstract;
using Emlakci.BLL.DTOs.ProductDTO;
using Emlakci.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICityService _cityService;
        private readonly ICategoryService _categoryService;
        private readonly IAgencyService _agencyService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, ICityService cityService, ICategoryService categoryService, IAgencyService agencyService, IMapper mapper)
        {
            _productService = productService;
            _cityService = cityService;
            _categoryService = categoryService;
            _agencyService = agencyService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAll();
            List<ResultProductDTO> models = _mapper.Map<List<ResultProductDTO>>(products);
            return View(models);
        }

        public IActionResult Create()
        {
            ViewBag.Cities = _cityService.GetAll();
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.Agencies = _agencyService.GetAll();

            return View(new CreateProductDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductDTO model, IFormFile file)
        {
            ModelState.Remove("CoverImage");
            ModelState.Remove("file");
            ModelState.Remove("City");
            ModelState.Remove("Category");
            ModelState.Remove("Agency");
            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    ModelState.AddModelError("", "Resim zorunludur.");

                    ViewBag.Cities = _cityService.GetAll();
                    ViewBag.Categories = _categoryService.GetAll();
                    ViewBag.Agencies = _agencyService.GetAll();
                    return View(model);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\RealEstate\\img", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                    model.CoverImage = file.FileName;
                }

                _productService.Create(_mapper.Map<Product>(model));

                return RedirectToAction("Index");
            }


            ViewBag.Cities = _cityService.GetAll();
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.Agencies = _agencyService.GetAll();
            return View(model);
        }
    }
}
