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
            CreateMap<BaseAddressModel, Supplier>()
                    .ForMember(vm => vm.Address, map => map.MapFrom(m => m.Address))
                    .ForMember(vm => vm.City, map => map.MapFrom(m => m.City))
                    .ForMember(vm => vm.Region, map => map.MapFrom(m => m.Region))
                    .ForMember(vm => vm.Country, map => map.MapFrom(m => m.Country))
                    .ForMember(vm => vm.PostalCode, map => map.MapFrom(m => m.PostalCode))
                    .ForMember(vm => vm.SupplierID, map => map.Ignore())
                    .ForMember(vm => vm.CompanyName, map => map.Ignore())
                    .ForMember(vm => vm.ContactName, map => map.Ignore())
                    .ForMember(vm => vm.ContactTitle, map => map.Ignore())
                    .ForMember(vm => vm.Phone, map => map.Ignore())
                    .ForMember(vm => vm.Fax, map => map.Ignore())
                    .ForMember(vm => vm.HomePage, map => map.Ignore())
                    .ForMember(vm => vm.Products, map => map.Ignore())
            .ReverseMap();

            CreateMap<BaseCommunicationModel, Supplier>()
               .ForMember(vm => vm.Phone, map => map.MapFrom(m => m.Phone))
               .ForMember(vm => vm.Fax, map => map.MapFrom(m => m.Fax))
               .ForMember(vm => vm.HomePage, map => map.MapFrom(m => m.HomePage))
               .ForMember(vm => vm.SupplierID, map => map.Ignore())
               .ForMember(vm => vm.CompanyName, map => map.Ignore())
               .ForMember(vm => vm.ContactName, map => map.Ignore())
               .ForMember(vm => vm.ContactTitle, map => map.Ignore())
               .ForMember(vm => vm.Address, map => map.Ignore())
               .ForMember(vm => vm.City, map => map.Ignore())
               .ForMember(vm => vm.Region, map => map.Ignore())
               .ForMember(vm => vm.Country, map => map.Ignore())
               .ForMember(vm => vm.PostalCode, map => map.Ignore())
               .ForMember(vm => vm.Products, map => map.Ignore())
            .ReverseMap();

            CreateMap<Supplier, SupplierModel>()
                 .ForMember(vm => vm.SupplierID, map => map.MapFrom(m => m.SupplierID))
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
                     HomePage = c.HomePage
                 }))
                 .ForAllOtherMembers(x => x.Ignore());

            CreateMap<SupplierModel, Supplier>()
                .ForMember(vm => vm.SupplierID, map => map.MapFrom(m => m.SupplierID))
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
                .ForMember(vm => vm.HomePage, map => map.MapFrom(m => m.CommunicationModel.HomePage))
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}