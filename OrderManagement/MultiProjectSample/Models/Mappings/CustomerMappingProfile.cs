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
            CreateMap<BaseAddressModel, Customer>()
                    .ForMember(vm => vm.Address, map => map.MapFrom(m => m.Address))
                    .ForMember(vm => vm.City, map => map.MapFrom(m => m.City))
                    .ForMember(vm => vm.Region, map => map.MapFrom(m => m.Region))
                    .ForMember(vm => vm.Country, map => map.MapFrom(m => m.Country))
                    .ForMember(vm => vm.PostalCode, map => map.MapFrom(m => m.PostalCode))
                    .ForMember(vm => vm.CustomerID, map => map.Ignore())
                    .ForMember(vm => vm.CompanyName, map => map.Ignore())
                    .ForMember(vm => vm.ContactName, map => map.Ignore())
                    .ForMember(vm => vm.ContactTitle, map => map.Ignore())
                    .ForMember(vm => vm.Phone, map => map.Ignore())
                    .ForMember(vm => vm.Fax, map => map.Ignore())
                    .ForMember(vm => vm.Orders, map => map.Ignore())
            .ReverseMap();

            CreateMap<BaseCommunicationModel, Customer>()
               .ForMember(vm => vm.Phone, map => map.MapFrom(m => m.Phone))
               .ForMember(vm => vm.Fax, map => map.MapFrom(m => m.Fax))
               .ForMember(vm => vm.CustomerID, map => map.Ignore())
               .ForMember(vm => vm.CompanyName, map => map.Ignore())
               .ForMember(vm => vm.ContactName, map => map.Ignore())
               .ForMember(vm => vm.ContactTitle, map => map.Ignore())
               .ForMember(vm => vm.Address, map => map.Ignore())
               .ForMember(vm => vm.City, map => map.Ignore())
               .ForMember(vm => vm.Region, map => map.Ignore())
               .ForMember(vm => vm.Country, map => map.Ignore())
               .ForMember(vm => vm.PostalCode, map => map.Ignore())
               .ForMember(vm => vm.Orders, map => map.Ignore())
            .ReverseMap();

            CreateMap<Customer, CustomerModel>()
                 .ForMember(vm => vm.CustomerID, map => map.MapFrom(m => m.CustomerID))
                 .ForMember(vm => vm.CompanyName, map => map.MapFrom(m => m.CompanyName))
                 .ForMember(vm => vm.ContactName, map => map.MapFrom(m => m.ContactName))
                 .ForMember(vm => vm.ContactTitle, map => map.MapFrom(m => m.ContactTitle))
                 .ForMember(vm => vm.AddressModel, map => map.MapFrom(c => new BaseAddressModel
                 {
                     Address = c.Address,
                     City = c.City,
                     Region = c.Region,
                     Country = c.Country,
                     PostalCode =
                     c.PostalCode
                 }))
                 .ForMember(vm => vm.CommunicationModel, map => map.MapFrom(c => new BaseCommunicationModel
                 {
                     Phone = c.Phone,
                     Fax = c.Fax,
                 }))
                 .ForAllOtherMembers(x => x.Ignore());

            CreateMap<CustomerModel, Customer>()
                .ForMember(vm => vm.CustomerID, map => map.MapFrom(m => m.CustomerID))
                .ForMember(vm => vm.CompanyName, map => map.MapFrom(m => m.CompanyName))
                .ForMember(vm => vm.ContactName, map => map.MapFrom(m => m.ContactName))
                .ForMember(vm => vm.ContactTitle, map => map.MapFrom(m => m.ContactTitle))
                .ForMember(vm => vm.Address, map => map.MapFrom(m => m.AddressModel.Address))
                .ForMember(vm => vm.City, map => map.MapFrom(m => m.AddressModel.City))
                .ForMember(vm => vm.Region, map => map.MapFrom(m => m.AddressModel.Region))
                .ForMember(vm => vm.Country, map => map.MapFrom(m => m.AddressModel.Country))
                .ForMember(vm => vm.PostalCode, map => map.MapFrom(m => m.AddressModel.PostalCode))
                .ForMember(vm => vm.Phone, map => map.MapFrom(m => m.CommunicationModel.Phone))
                .ForMember(vm => vm.Fax, map => map.MapFrom(m => m.CommunicationModel.Fax))
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}