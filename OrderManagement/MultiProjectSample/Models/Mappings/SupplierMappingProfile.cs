using AutoMapper;
using Hk.Application1.Core.Models;
using Hk.Utilities.Interfaces;
using MultiProjectSample.Models.Models;

namespace MultiProjectSample.Models.Mappings
{
    public class SupplierMappingProfile : Profile, IAmAutoMapperProfile
    {
        public override string ProfileName
        {
            get { return "SupplierMappingProfile"; }
        }

        public SupplierMappingProfile()
        {
            CreateMap<Supplier, SupplierModel>()
                 .ForMember(vm => vm.SupplierID, map => map.MapFrom(m => m.SupplierID))
                 .ForMember(vm => vm.CompanyName, map => map.MapFrom(m => m.CompanyName))
                 .ForMember(vm => vm.ContactName, map => map.MapFrom(m => m.ContactName))
                 .ForMember(vm => vm.ContactTitle, map => map.MapFrom(m => m.ContactTitle))
                 .ForMember(vm => vm.Address, map => map.MapFrom(m => m.Address))
                 .ForMember(vm => vm.City, map => map.MapFrom(m => m.City))
                 .ForMember(vm => vm.Region, map => map.MapFrom(m => m.Region))
                 .ForMember(vm => vm.PostalCode, map => map.MapFrom(m => m.PostalCode))
                 .ForMember(vm => vm.Country, map => map.MapFrom(m => m.Country))
                 .ForMember(vm => vm.Phone, map => map.MapFrom(m => m.Phone))
                 .ForMember(vm => vm.Fax, map => map.MapFrom(m => m.Fax))
                 .ForMember(vm => vm.HomePage, map => map.MapFrom(m => m.HomePage))
            .ReverseMap();
        }
    }
}