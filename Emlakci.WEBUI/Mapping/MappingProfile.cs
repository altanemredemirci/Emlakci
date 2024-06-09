using AutoMapper;
using Emlakci.BLL.DTOs.AgencyDTO;
using Emlakci.BLL.DTOs.CategoryDTO;
using Emlakci.BLL.DTOs.MailDTO;
using Emlakci.BLL.DTOs.ProductDetailDTO;
using Emlakci.BLL.DTOs.ProductDTO;
using Emlakci.BLL.DTOs.SliderDTO;
using Emlakci.BLL.DTOs.TodoListDTO;
using Emlakci.BLL.DTOs.WhoWeAreDTO;
using Emlakci.Entity;

namespace Emlakci.WEBUI.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, ResultCategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();

            CreateMap<Product, ResultProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();

            CreateMap<ProductDetails, CreateProductDetailDTO>().ReverseMap();

            CreateMap<Agency, ResultAgencyDTO>().ReverseMap();
            CreateMap<Agency, CreateAgencyDTO>().ReverseMap();
            CreateMap<Agency, UpdateAgencyDTO>().ReverseMap();

            CreateMap<Slider, ResultSliderDTO>().ReverseMap();
            CreateMap<Slider, CreateSliderDTO>().ReverseMap();
            CreateMap<Slider, UpdateSliderDTO>().ReverseMap();

            CreateMap<WhoWeAre, ResultWhoWeAreDTO>().ReverseMap();
            CreateMap<WhoWeAre, UpdateWhoWeAreDTO>().ReverseMap();

            CreateMap<Mail, ResultMailDTO>().ReverseMap();
            CreateMap<TodoList, ResultTodoListDTO>().ReverseMap();
        }
    }
}
