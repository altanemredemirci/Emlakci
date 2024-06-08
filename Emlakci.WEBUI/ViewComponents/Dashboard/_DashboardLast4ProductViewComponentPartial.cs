using AutoMapper;
using Emlakci.BLL.Abstract;
using Emlakci.BLL.DTOs.ProductDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace Emlakci.WEBUI.ViewComponents.Dashboard
{
    public class _DashboardLast4ProductViewComponentPartial:ViewComponent
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public _DashboardLast4ProductViewComponentPartial(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var model = _productService.Last4Product();
            return View(_mapper.Map<List<ResultProductDTO>>(model));
        }
    }
}
