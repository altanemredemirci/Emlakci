using AutoMapper;
using Emlakci.BLL.Abstract;
using Emlakci.BLL.DTOs.ProductDTO;
using Emlakci.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.ViewComponents.Home
{
    public class _HomeProductListViewComponentPartial : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public _HomeProductListViewComponentPartial(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            //List<ResultProductModel> resultProductModels = new List<ResultProductModel>();

            //foreach (var item in _productService.GetAll())
            //{
            //    resultProductModels.Add(new ResultProductModel()
            //    {
            //        Id = item.Id,
            //        Title = item.Title,
            //        Price = item.Price,
            //        City = item.City,
            //        District = item.District,
            //        Address = item.Address,
            //        CategoryName = item.Category.Name,
            //        CoverImage = item.CoverImage,
            //        Type=item.Type
            //    });
            //}

            var products = _productService.GetAll();
            List<ResultProductDTO> resultProductModels = _mapper.Map<List<ResultProductDTO>>(products);

            return View(resultProductModels);
        }
    }
}
