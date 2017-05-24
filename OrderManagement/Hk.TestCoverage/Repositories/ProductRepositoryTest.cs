using Castle.Windsor;
using Castle.Windsor.Installer;
using Hk.Application1.Core.Models;
using Hk.Application1.Data.Models;
using Hk.Application1.Repository.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Hk.TestCoverage.Repositories
{
    [TestClass]
    public class ProductRepositoryTest
    {
        private IProductRepository iProductRepository;
        private DatabaseContext databaseContext;

        [TestInitialize]
        public void SetupTest()
        {
            using (IWindsorContainer _container = new WindsorContainer())
            {
                _container.Install(FromAssembly.This());

                databaseContext = _container.Resolve<DatabaseContext>();
                iProductRepository = _container.Resolve<IProductRepository>();
            }
        }

        [TestMethod]
        public void ProductRepository_GetAllProducts()
        {
            IEnumerable<Product> productData = iProductRepository.GetAll();
            Assert.IsNotNull(productData);
            Assert.AreNotEqual(0, ((IEnumerable<Product>)productData).Count<Product>());
        }
    }
}
