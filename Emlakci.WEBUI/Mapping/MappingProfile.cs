using AutoMapper;
using Emlakci.BLL.DTOs.AgencyDTO;
using Emlakci.BLL.DTOs.CategoryDTO;
using Emlakci.BLL.DTOs.ProductDTO;
using Emlakci.BLL.DTOs.SliderDTO;
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

            CreateMap<Agency, ResultAgencyDTO>().ReverseMap();
            CreateMap<Agency, CreateAgencyDTO>().ReverseMap();
            CreateMap<Agency, UpdateAgencyDTO>().ReverseMap();

            CreateMap<Slider, ResultSliderDTO>().ReverseMap();

            CreateMap<WhoWeAre, ResultWhoWeAreDTO>().ReverseMap();
            CreateMap<WhoWeAre, UpdateWhoWeAreDTO>().ReverseMap();
        }
    }
}
