using AutoMapper;
using e_commercial_Domain.Dtos.ProductDtos;
using e_commercial_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commercial_Repository.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(p => p.ProductBrand, b => b.MapFrom(o => o.ProductBrand.Name))
                .ForMember(p => p.ProductType, t => t.MapFrom(o => o.ProductType.Name))
                .ForMember(p => p.PictureUrl, d => d.MapFrom<ProductPictureUrlResolver>());



        }
    }
}
