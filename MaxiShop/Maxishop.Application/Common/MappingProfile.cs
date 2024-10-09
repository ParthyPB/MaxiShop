using AutoMapper;
using Maxishop.Application.DTO.Brand;
using Maxishop.Application.DTO.Category;
using Maxishop.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxishop.Application.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateCategoryDTO, Category>().ReverseMap();
            CreateMap<UpdateCategoryDTO, Category>().ReverseMap();
            CreateMap<CategoryDTO, Category>().ReverseMap();
            CreateMap<BrandDTO, Brand>().ReverseMap();
            CreateMap<CreateBrandDTO,Brand>().ReverseMap();
            CreateMap<UpdateBrandDTO, Brand>().ReverseMap();
        }
    }
}
