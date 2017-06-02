using AutoMapper;
using Hk.Application1.Core.Models;
using Hk.Utilities.Interfaces;
using MultiProjectSample.Models.Models;

namespace MultiProjectSample.Models.Mappings
{
    public class OrderMappingProfile : Profile, IAmAutoMapperProfile
    {
        public override string ProfileName
        {
            get { return "OrderMappingProfile"; }
        }

        public OrderMappingProfile()
        {
            CreateMap<Order_Detail, OrderDetailsModel>()
                .ForMember(vm => vm.OrderID, map => map.MapFrom(m => m.OrderID))
                .ForMember(vm => vm.ProductID, map => map.MapFrom(m => m.ProductID))
                .ForMember(vm => vm.UnitPrice, map => map.MapFrom(m => m.UnitPrice))
                .ForMember(vm => vm.Quantity, map => map.MapFrom(m => m.Quantity))
                .ForMember(vm => vm.Discount, map => map.MapFrom(m => m.Discount))
                .ForMember(vm => vm.Product, map => map.MapFrom(m => m.Product))
                .ReverseMap();

            CreateMap<BaseAddressModel, Order>()
                    .ForMember(vm => vm.ShipAddress, map => map.MapFrom(m => m.Address))
                    .ForMember(vm => vm.ShipCity, map => map.MapFrom(m => m.City))
                    .ForMember(vm => vm.ShipRegion, map => map.MapFrom(m => m.Region))
                    .ForMember(vm => vm.ShipCountry, map => map.MapFrom(m => m.Country))
                    .ForMember(vm => vm.ShipPostalCode, map => map.MapFrom(m => m.PostalCode))
                    .ForMember(vm => vm.OrderID, map => map.Ignore())
                    .ForMember(vm => vm.CustomerID, map => map.Ignore())
                    .ForMember(vm => vm.OrderDate, map => map.Ignore())
                    .ForMember(vm => vm.RequiredDate, map => map.Ignore())
                    .ForMember(vm => vm.ShipName, map => map.Ignore())
                    .ForMember(vm => vm.ShippedDate, map => map.Ignore())
                    .ForMember(vm => vm.Freight, map => map.Ignore())
                    .ForMember(vm => vm.Order_Details, map => map.Ignore())
                    .ForMember(vm => vm.Customer, map => map.Ignore())
            .ReverseMap();

            CreateMap<Order, OrderModel>()
                 .ForMember(vm => vm.OrderID, map => map.MapFrom(m => m.OrderID))
                 .ForMember(vm => vm.CustomerID, map => map.MapFrom(m => m.CustomerID))
                 .ForMember(vm => vm.OrderDate, map => map.MapFrom(m => m.OrderDate))
                 .ForMember(vm => vm.RequiredDate, map => map.MapFrom(m => m.RequiredDate))
                 .ForMember(vm => vm.ShipName, map => map.MapFrom(m => m.ShipName))
                 .ForMember(vm => vm.ShippedDate, map => map.MapFrom(m => m.ShippedDate))
                 .ForMember(vm => vm.Freight, map => map.MapFrom(m => m.Freight))
                 .ForMember(vm => vm.AddressModel, map => map.MapFrom(c => new BaseAddressModel
                 {
                     Address = c.ShipAddress,
                     City = c.ShipCity,
                     Region = c.ShipRegion,
                     Country = c.ShipCountry,
                     PostalCode = c.ShipPostalCode
                 }))
                 .ForMember(vm => vm.Order_Details, map => map.MapFrom(m => m.Order_Details))
                 .ForMember(vm => vm.Customer, map => map.MapFrom(m => m.Customer))
                 .ForAllOtherMembers(x => x.Ignore());

            CreateMap<OrderModel, Order>()
                .ForMember(vm => vm.OrderID, map => map.MapFrom(m => m.OrderID))
                .ForMember(vm => vm.CustomerID, map => map.MapFrom(m => m.CustomerID))
                .ForMember(vm => vm.OrderDate, map => map.MapFrom(m => m.OrderDate))
                .ForMember(vm => vm.RequiredDate, map => map.MapFrom(m => m.RequiredDate))
                .ForMember(vm => vm.ShippedDate, map => map.MapFrom(m => m.ShippedDate))
                .ForMember(vm => vm.ShipName, map => map.MapFrom(m => m.ShipName))
                .ForMember(vm => vm.Freight, map => map.MapFrom(m => m.Freight))
                .ForMember(vm => vm.ShipAddress, map => map.MapFrom(m => m.AddressModel.Address))
                .ForMember(vm => vm.ShipCity, map => map.MapFrom(m => m.AddressModel.City))
                .ForMember(vm => vm.ShipRegion, map => map.MapFrom(m => m.AddressModel.Region))
                .ForMember(vm => vm.ShipCountry, map => map.MapFrom(m => m.AddressModel.Country))
                .ForMember(vm => vm.ShipPostalCode, map => map.MapFrom(m => m.AddressModel.PostalCode))
                .ForMember(vm => vm.Order_Details, map => map.MapFrom(m => m.Order_Details))
                .ForMember(vm => vm.Customer, map => map.MapFrom(m => m.Customer))
                .ForAllOtherMembers(x => x.Ignore());


        }
    }
}