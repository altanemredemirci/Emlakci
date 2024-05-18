using AutoMapper;
using Emlakci.BLL.Abstract;
using Emlakci.BLL.DTOs.ProductDTO;
using Emlakci.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Emlakci.WEBUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        //Injection
        public HomeController(ICategoryService categoryService,IProductService productService,IMapper mapper)
        {
            _categoryService = categoryService;
            _productService = productService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(_categoryService.GetAll());
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult ProductDetail(int id)
        {
            return View(id);
        }
    }
}
