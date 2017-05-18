using AutoMapper;
using Hk.Application1.Core.Models;
using Hk.Utilities.Interfaces;
using MultiProjectSample.Models.Models;

namespace MultiProjectSample.Models.Mappings
{
    public class CategoryMappingProfile : Profile, IAmAutoMapperProfile
    {
        public override string ProfileName
        {
            get { return "CategoryMappingProfile"; }
        }

        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryModel>()
                 .ForMember(vm => vm.CategoryID, map => map.MapFrom(m => m.CategoryID))
                 .ForMember(vm => vm.CategoryName, map => map.MapFrom(m => m.CategoryName))
                 .ForMember(vm => vm.Description, map => map.MapFrom(m => m.Description))
                 .ForMember(vm => vm.Picture, map => map.MapFrom(m => System.Convert.ToBase64String(m.Picture)));

            CreateMap<CategoryModel, Category>()
                 .ForMember(vm => vm.CategoryID, map => map.MapFrom(m => m.CategoryID))
                 .ForMember(vm => vm.CategoryName, map => map.MapFrom(m => m.CategoryName))
                 .ForMember(vm => vm.Description, map => map.MapFrom(m => m.Description))
                 .ForMember(vm => vm.Picture, map => map.Ignore())
                 .ForMember(vm => vm.Products, map => map.Ignore());
        }
    }
}