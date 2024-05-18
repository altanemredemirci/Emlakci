using AutoMapper;
using Emlakci.BLL.Abstract;
using Emlakci.BLL.DTOs.ProductDTO;
using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.ViewComponents.Home
{
    public class _HomeProductDetailPopularViewComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public _HomeProductDetailPopularViewComponentPartial(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke(int id)
        {
            var products = _productService.GetAll(i => i.IsFavorite == true);
            List<ResultProductDTO> resultProductModels = _mapper.Map<List<ResultProductDTO>>(products);

            return View(resultProductModels);
        }
    }
}