using AutoMapper;
using Hk.Application1.Core.Models;
using Hk.Utilities.Interfaces;
using MultiProjectSample.Models.Models;

namespace MultiProjectSample.Models.Mappings
{
    public class CustomerMappingProfile : Profile, IAmAutoMapperProfile
    {
        public override string ProfileName
        {
            get { return "CustomerMappingProfile"; }
        }

        public CustomerMappingProfile()
        {
            CreateMap<Customer, CustomerModel>()
                 .ForMember(vm => vm.CustomerID, map => map.MapFrom(m => m.CustomerID))
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
            .ReverseMap();
        }
    }
}