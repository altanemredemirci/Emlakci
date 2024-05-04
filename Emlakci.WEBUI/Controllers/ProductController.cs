using AutoMapper;
using Emlakci.BLL.Abstract;
using Emlakci.BLL.DTOs.ProductDTO;
using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAll();
            List<ResultProductDTO> models = _mapper.Map<List<ResultProductDTO>>(products);
            return View(models);
        }
    }
}
