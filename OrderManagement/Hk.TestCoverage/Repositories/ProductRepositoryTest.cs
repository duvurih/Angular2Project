using Castle.Windsor;
using Castle.Windsor.Installer;
using Hk.Application1.Core.Models;
using Hk.Application1.Data.Models;
using Hk.Application1.Repository.Interface;
using Hk.Application1.Repository.Repositories;
using Hk.TestCoverage.DataInitialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
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
            //Initializing Test Data
            IEnumerable<Product> inputTestData = ProductDataInitialization.ProductTestData();
            var mockSet = new Mock<DbSet<Product>>();

            //creating mock objects
            var databaseContextMock = new Mock<DatabaseContext>();
            var iProductRepositoryMock = new Mock<IProductRepository>();

            //setting-up mock objects
            databaseContextMock.Setup(x => x.Set<Product>()).Returns(mockSet.Object);
            iProductRepositoryMock.Setup(x => x.GetAll()).Returns(inputTestData);

            //Object Creation and Invocation
            ProductRepository productRepository = new ProductRepository(databaseContextMock.Object);
            IEnumerable<Product> productData = productRepository.GetAll();

            //Results Comparison
            Assert.IsNotNull(productData);
            Assert.AreNotEqual(0, ((IEnumerable<Product>)productData).Count<Product>());
        }

        public void ProductRepository_GetProductsByCategory()
        {
            IEnumerable<Product> productData = iProductRepository.GetProductsByCategory(1);
            Assert.IsNotNull(productData);
            Assert.AreNotEqual(0, ((IEnumerable<Product>)productData).Count<Product>());

        }
    }
}
