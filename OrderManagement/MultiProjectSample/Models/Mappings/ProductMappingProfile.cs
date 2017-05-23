using AutoMapper;
using Hk.Application1.Core.Models;
using Hk.Utilities.Interfaces;
using MultiProjectSample.Models.Models;

namespace MultiProjectSample.Models.Mappings
{
    public class ProductMappingProfile : Profile, IAmAutoMapperProfile
    {
        public override string ProfileName
        {
            get { return "ProductMappintProfile"; }
        }

        public ProductMappingProfile()
        {
            CreateMap<Product, ProductModel>()
                 .ForMember(vm => vm.ProductID, map => map.MapFrom(m => m.ProductID))
                 .ForMember(vm => vm.CategoryID, map => map.MapFrom(m => m.CategoryID))
                 .ForMember(vm => vm.ProductName, map => map.MapFrom(m => m.ProductName))
                 .ForMember(vm => vm.SupplierID, map => map.MapFrom(m => m.SupplierID))
                 .ForMember(vm => vm.QuantityPerUnit, map => map.MapFrom(m => m.QuantityPerUnit))
                 .ForMember(vm => vm.UnitPrice, map => map.MapFrom(m => m.UnitPrice))
                 .ForMember(vm => vm.UnitsInStock, map => map.MapFrom(m => m.UnitsInStock))
                 .ForMember(vm => vm.UnitsOnOrder, map => map.MapFrom(m => m.UnitsOnOrder))
                 .ForMember(vm => vm.ReorderLevel, map => map.MapFrom(m => m.ReorderLevel))
                 .ForMember(vm => vm.Discontinued, map => map.MapFrom(m => m.Discontinued))
            .ReverseMap();
        }
    }
}