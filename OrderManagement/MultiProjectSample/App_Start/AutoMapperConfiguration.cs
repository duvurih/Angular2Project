using AutoMapper;
using Hk.Utilities.Interfaces;
using MultiProjectSample.Models.Mappings;
using System;
using System.Linq;

namespace MultiProjectSample.App_Start
{
    public class AutoMapperConfiguration
    {
        //public static MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
        //{
        //    cfg.AddProfile<CategoryMappingProfile>();
        //    cfg.AddProfile<ProductMappingProfile>();
        //    cfg.AddProfile<CustomerMappingProfile>();
        //    cfg.AddProfile<SupplierMappingProfile>();

        //    //cfg.ShouldMapProperty = pi => !pi.Name.InList("HiddenSwitch", "ErrorMessage",
        //    //                         "SuccessMessage", "WarningMessage", "DuplicateForm");
        //});

        //public static IMapper Mapper;

        public static void Configuration()
        {
            //Mapper.Initialize(x => GetConfiguration());

            Mapper.Initialize(m =>
            {
                m.AddProfile<CategoryMappingProfile>();
                m.AddProfile<ProductMappingProfile>();
                m.AddProfile<CustomerMappingProfile>();
                m.AddProfile<SupplierMappingProfile>();
            });
            //Mapper = mapperConfiguration.CreateMapper();
            Mapper.AssertConfigurationIsValid();
        }

        private static void GetConfiguration()
        {
            var type = typeof(IAmAutoMapperProfile);
            var profiles = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));

            foreach (var profile in profiles)
            {
                if (profile.IsInterface == false)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.AddProfile(Activator.CreateInstance(profile) as Profile);
                    });
                }
            }
        }
    }
}