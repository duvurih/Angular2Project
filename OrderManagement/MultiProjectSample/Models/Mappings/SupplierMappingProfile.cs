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
            //CreateMap<SupplierModel, Supplier>()
            //    .ForMember(vm => vm.SupplierID, map => map.MapFrom(m => m.SupplierID))
            //    .ForMember(vm => vm.CompanyName, map => map.MapFrom(m => m.CompanyName))
            //    .ForMember(vm => vm.ContactName, map => map.MapFrom(m => m.ContactName))
            //    .ForMember(vm => vm.ContactTitle, map => map.MapFrom(m => m.ContactTitle))
            //    .ForMember(vm => vm.City, map => map.MapFrom(m => m.Address.City))
            //    .ForMember(vm => vm.Region, map => map.MapFrom(m => m.Address.Region))
            //    .ForMember(vm => vm.PostalCode, map => map.MapFrom(m => m.Address.PostalCode))
            //    .ForMember(vm => vm.Country, map => map.MapFrom(m => m.Address.Country))
            //    .ForMember(vm => vm.Phone, map => map.MapFrom(m => m.Communication.Phone))
            //    .ForMember(vm => vm.Fax, map => map.MapFrom(m => m.Communication.Fax))
            //    .ForMember(vm => vm.HomePage, map => map.MapFrom(m => m.Communication.HomePage))
            //.ReverseMap();

            //CreateMap<SupplierModel, BaseAddressModel>()
            //    .ForMember(vm => vm.City, map => map.MapFrom(m => m.Address.City))
            //    .ForMember(vm => vm.Region, map => map.MapFrom(m => m.Address.Region))
            //    .ForMember(vm => vm.PostalCode, map => map.MapFrom(m => m.Address.PostalCode))
            //    .ForMember(vm => vm.Country, map => map.MapFrom(m => m.Address.Country))
            //.ReverseMap();

            //CreateMap<SupplierModel, BaseCommunicationModel>()
            //    .ForMember(vm => vm.Phone, map => map.MapFrom(m => m.Communication.Phone))
            //    .ForMember(vm => vm.Fax, map => map.MapFrom(m => m.Communication.Fax))
            //    .ForMember(vm => vm.HomePage, map => map.MapFrom(m => m.Communication.HomePage))
            //.ReverseMap();

            CreateMap<Supplier, SupplierModel>()
                .ForMember(vm => vm.SupplierID, map => map.MapFrom(m => m.SupplierID))
                .ForMember(vm => vm.CompanyName, map => map.MapFrom(m => m.CompanyName))
                .ForMember(vm => vm.ContactName, map => map.MapFrom(m => m.ContactName))
                .ForMember(vm => vm.ContactTitle, map => map.MapFrom(m => m.ContactTitle))
                .ForMember(vm => vm.Address, map => map.MapFrom(c => new BaseAddressModel { Address = c.Address, City = c.City, Region = c.Region, Country = c.Country, PostalCode = c.PostalCode }))
                .ForMember(vm => vm.Communication, map => map.MapFrom(c => new BaseCommunicationModel { Phone = c.Phone, Fax = c.Fax, HomePage = c.HomePage }))
            .ReverseMap();



            //CreateMap<Supplier, SupplierModel>()
            //      .ForMember(vm => vm.SupplierID, map => map.MapFrom(m => m.SupplierID))
            //      .ForMember(vm => vm.CompanyName, map => map.MapFrom(m => m.CompanyName))
            //      .ForMember(vm => vm.ContactName, map => map.MapFrom(m => m.ContactName))
            //      .ForMember(vm => vm.ContactTitle, map => map.MapFrom(m => m.ContactTitle))
            //      .ForMember(vm => vm.Address.City, map => map.MapFrom(m => m.City))
            //      .ForMember(vm => vm.Address.Region, map => map.MapFrom(m => m.Region))
            //      .ForMember(vm => vm.Address.PostalCode, map => map.MapFrom(m => m.PostalCode))
            //      .ForMember(vm => vm.Address.Country, map => map.MapFrom(m => m.Country))
            //      .ForMember(vm => vm.Communication.Phone, map => map.MapFrom(m => m.Phone))
            //      .ForMember(vm => vm.Communication.Fax, map => map.MapFrom(m => m.Fax))
            //      .ForMember(vm => vm.Communication.HomePage, map => map.MapFrom(m => m.HomePage))
            //.ReverseMap();
        }
    }
}