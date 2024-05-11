using AutoMapper;
using Emlakci.BLL.Abstract;
using Emlakci.BLL.DTOs.ProductDTO;
using Emlakci.Entity;
using Emlakci.WEBUI.Mapping;
using Emlakci.WEBUI.Models;
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

                model.CoverImage = await ImageMethod.UploadImage(file);
                _productService.Create(_mapper.Map<Product>(model));

                return RedirectToAction("Index");
            }


            ViewBag.Cities = _cityService.GetAll();
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.Agencies = _agencyService.GetAll();
            return View(model);
        }


        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                ErrorViewModel error = new ErrorViewModel()
                {
                    Title="NOT FOUND",
                    Message="Do not found searched",
                    ReturnUrl="/product/Index"
                };

                return View("Error", error);
            }

            var product = _productService.GetById(id);

            if (product == null)
            {

            }

            var model = _mapper.Map<UpdateProductDTO>(product);

            ViewBag.Cities = _cityService.GetAll();
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.Agencies = _agencyService.GetAll();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateProductDTO model, IFormFile file)
        {
            ModelState.Remove("CoverImage");
            ModelState.Remove("City");
            ModelState.Remove("file");
            ModelState.Remove("Category");
            ModelState.Remove("Agency");
            if (ModelState.IsValid)
            {
                var product = _productService.GetById(model.Id);

                if (file != null)
                {
                    ImageMethod.DeleteImage(product.CoverImage);
                                        
                    model.CoverImage= await ImageMethod.UploadImage(file);
                }

               _productService.Update(_mapper.Map<Product>(model));

                return RedirectToAction("Index");
            }


            ViewBag.Cities = _cityService.GetAll();
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.Agencies = _agencyService.GetAll();
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            if (id < 1)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel()
                {
                    Title = "Bad Request",
                    Message = "Id gönderilmedi",
                    ReturnUrl = "/Product/Index"
                };

                return View("Error", errorViewModel);

            }
            var product = _productService.GetById(id);

            if (product == null)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel()
                {
                    Title = "Not Found",
                    Message = "İlan bulunamadı",
                    ReturnUrl = "/Product/Index"
                };
                return View("Error", errorViewModel);
            }

            _productService.Delete(product);
            ImageMethod.DeleteImage(product.CoverImage);

            return RedirectToAction("Index");
        }


       



    }
}
