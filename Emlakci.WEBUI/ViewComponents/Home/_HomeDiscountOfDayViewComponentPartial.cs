using AutoMapper;
using Emlakci.BLL.Abstract;
using Emlakci.BLL.DTOs.ProductDTO;
using Emlakci.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.ViewComponents.Home
{
    public class _HomeDiscountOfDayViewComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public _HomeDiscountOfDayViewComponentPartial(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var products = _productService.GetAll();
            List<ResultProductDTO> resultProductModels = _mapper.Map<List<ResultProductDTO>>(products);

            return View(resultProductModels);
        }
    }
}