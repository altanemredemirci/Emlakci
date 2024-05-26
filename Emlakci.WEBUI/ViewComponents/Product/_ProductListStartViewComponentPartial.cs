using AutoMapper;
using Emlakci.BLL.Abstract;
using Emlakci.BLL.DTOs.ProductDTO;
using Emlakci.BLL.DTOs.SliderDTO;
using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.ViewComponents.Product
{
    public class _ProductListStartViewComponentPartial : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public _ProductListStartViewComponentPartial(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var products = _productService.GetAll(i => i.Status == true);
            List<ResultProductDTO> resultProductModels = _mapper.Map<List<ResultProductDTO>>(products);

            return View(resultProductModels);
        }
    }
}
