using AutoMapper;
using ProjectClean.Application.ViewModels;
using ProjectClean.Domain.Entities;

namespace ProjectClean.Application.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}