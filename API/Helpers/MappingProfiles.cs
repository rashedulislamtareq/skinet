using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
            .ForMember(y=>y.ProductBrand, x=>x.MapFrom(z=>z.ProductBrand.Name))//Mapped Product Brand Name
            .ForMember(y=>y.ProductType, x=>x.MapFrom(z=>z.ProductType.Name)) //Mapped Product Type Name
            .ForMember(y=>y.PictureUrl, x=>x.MapFrom<ProductUrlResolver>()); //Mapped Product Url
        }        
    }
}