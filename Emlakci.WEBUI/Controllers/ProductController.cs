using AutoMapper;
using Emlakci.BLL.Abstract;
using Emlakci.BLL.DTOs.ProductDetailDTO;
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
        private readonly IProductDetailService _productDetailService;
        private readonly ICityService _cityService;
        private readonly ICategoryService _categoryService;
        private readonly IAgencyService _agencyService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, ICityService cityService, ICategoryService categoryService, IAgencyService agencyService, IMapper mapper, IProductDetailService productDetailService)
        {
            _productService = productService;
            _cityService = cityService;
            _categoryService = categoryService;
            _agencyService = agencyService;
            _mapper = mapper;
            _productDetailService = productDetailService;
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

            return View(new CreateProductDetailDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductDetailDTO dto, IFormFile file, IFormFile[] files)
        {
            ModelState.Remove("Product.CoverImage");
            ModelState.Remove("file");
            ModelState.Remove("Product.City");
            ModelState.Remove("Product.Category");
            ModelState.Remove("Product.Agency");
            ModelState.Remove("Images");
            ModelState.Remove("Product.ProductDetails");
            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    ViewBag.Cities = _cityService.GetAll();
                    ViewBag.Categories = _categoryService.GetAll();
                    ViewBag.Agencies = _agencyService.GetAll();
                    ModelState.AddModelError("", "Ana resim için dosya yüklenmedi.");
                    return View(dto);
                }

                if (files.Length == 0)
                {
                    ViewBag.Cities = _cityService.GetAll();
                    ViewBag.Categories = _categoryService.GetAll();
                    ViewBag.Agencies = _agencyService.GetAll();
                    ModelState.AddModelError("", "İlan Detay Resimleri yüklenmedi.");
                    return View(dto);
                }

                dto.Product.CoverImage = await ImageMethod.UploadImage(file);

                foreach (var item in files)
                {
                    Entity.Image image = new Entity.Image();
                    image.Url = await ImageMethod.UploadImage(item);
                    dto.Images.Add(image);
                }
                dto.Product.Status = true;
                dto.PublishDate = DateTime.Now;
                //_productService.Create(_mapper.Map<Product>(dto.Product));
                _productDetailService.Create(_mapper.Map<ProductDetails>(dto));

                return RedirectToAction("Index");
            }


            ViewBag.Cities = _cityService.GetAll();
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.Agencies = _agencyService.GetAll();
            return View(dto);
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

            var productDetail = _productDetailService.GetById(id);

            if (productDetail == null)
            {
                ErrorViewModel error = new ErrorViewModel()
                {                   
                    Title = "İlan Bulunamadı",
                    Message = "Lütfen varolan bir ilanı seçiniz.",
                    ReturnUrl = "/Product/Index"
                };
                return View("Error", error);
            }

            var model = _mapper.Map<UpdateProductDetailDTO>(productDetail);

            ViewBag.Cities = _cityService.GetAll();
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.Agencies = _agencyService.GetAll();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateProductDetailDTO model, IFormFile file, IFormFile[] files)
        {
            ModelState.Remove("Product.CoverImage");
            ModelState.Remove("Product.City");
            ModelState.Remove("file");
            ModelState.Remove("Product.Category");
            ModelState.Remove("Product.Agency");
            ModelState.Remove("Product.ProductDetails");
            if (ModelState.IsValid)
            {
                var productDetail = _productDetailService.GetById(model.ProductId);

                if (productDetail == null)
                {
                    ErrorViewModel error = new ErrorViewModel()
                    {
                        Title = "İlan Bulunamadı",
                        Message = "Lütfen varolan bir ilanı seçiniz.",
                        ReturnUrl = "/Product/Index"
                    };
                    return View("Error", error);
                }

                if (file != null)
                {
                    ImageMethod.DeleteImage(productDetail.Product.CoverImage);
                                        
                    model.Product.CoverImage= await ImageMethod.UploadImage(file);
                }
                else
                {
                    model.Product.CoverImage = productDetail.Product.CoverImage;
                }

                if (files != null)
                {
                    productDetail.Images.ForEach(i => ImageMethod.DeleteImage(i.Url));

                    foreach (var item in files)
                    {
                        Image image = new Image();
                        image.Url = await ImageMethod.UploadImage(item);
                        model.Images.Add(image);
                    }
                }

                else
                {
                    //foreach (var item in productDetail.Images)
                    //{
                    //    Image image = new Image();
                    //    image.Url = item.Url;
                    //    image.ProductDetailsId = item.ProductDetailsId;
                    //    model.Images.Add(image);
                    //}

                    model.Images = productDetail.Images;
                }
                model.Product.Status = true;
               _productDetailService.Update(_mapper.Map<ProductDetails>(model));

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

        public IActionResult StatusChange(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                ErrorViewModel error = new ErrorViewModel()
                {
                    Title = "NOT FOUND",
                    Message = "Do not found searched",
                    ReturnUrl = "/product/Index"
                };
            }
            product.IsFavorite= product.IsFavorite == true ? false : true;

            _productService.Update(product);

            return RedirectToAction("Index");
        }
    }
}
