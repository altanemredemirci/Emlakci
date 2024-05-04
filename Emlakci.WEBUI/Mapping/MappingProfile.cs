﻿using AutoMapper;
using Emlakci.BLL.DTOs.CategoryDTO;
using Emlakci.BLL.DTOs.ProductDTO;
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
        }
    }
}