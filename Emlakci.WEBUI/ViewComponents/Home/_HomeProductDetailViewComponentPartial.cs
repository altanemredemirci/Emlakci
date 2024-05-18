using AutoMapper;
using Emlakci.BLL.Abstract;
using Emlakci.BLL.DTOs.ProductDTO;
using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.ViewComponents.Home
{
    public class _HomeProductDetailViewComponentPartial:ViewComponent
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public _HomeProductDetailViewComponentPartial(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke(int id)
        {
            var product = _productService.GetById(id);
            var model = _mapper.Map<ResultProductDTO>(product);
            return View(model);
        }
    }
}
