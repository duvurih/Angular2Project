using Castle.Windsor;
using Castle.Windsor.Installer;
using Hk.Application1.Core.Interfaces;
using Hk.Application1.Core.Models;
using Hk.Application1.Core.ModelsHk.Application1.Services.Products;
using Hk.Application1.Repository.Interface;
using Hk.TestCoverage.DataInitialization;
using Hk.Utilities.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Hk.TestCoverage.Services
{
    [TestClass]
    public class ProductServiceTest
    {
        private IProductService iProductService;
        private IProductRepository iProductRepository;

        [TestInitialize]
        public void SetupTest()
        {
            using (IWindsorContainer _container = new WindsorContainer())
            {
                _container.Install(FromAssembly.This());

                iProductService = _container.Resolve<IProductService>();
                iProductRepository = _container.Resolve<IProductRepository>();
            }
        }

        [TestMethod]
        public void ProductService_GetAllProducts()
        {
            //Initializing Test Data
            IEnumerable<Product> inputTestData = ProductDataInitialization.ProductTestData();

            //creating mock objects
            var iProductRepositoryMock = new Mock<IProductRepository>();
            var iUnitOfWorkMock = new Mock<IUnitOfWork>();
            var iServiceManagerMock = new Mock<IServiceManager>();

            //setting-up mock objects
            iProductRepositoryMock.Setup(x => x.GetAll()).Returns(inputTestData);

            //Object Creation and Invocation
            ProductService productService = new ProductService(iProductRepositoryMock.Object, iUnitOfWorkMock.Object, iServiceManagerMock.Object);
            IEnumerable<Product> productData = productService.GetAll();

            //Results Comparison
            Assert.IsNotNull(productData);
            Assert.AreNotEqual(0, ((IEnumerable<Product>)productData).Count<Product>());
            Assert.AreEqual(10, ((IEnumerable<Product>)productData).Count<Product>());
        }

        [TestMethod]
        public void ProductService_GetProductsByCategory()
        {
            //Initializing Test Data
            IEnumerable<Product> inputTestData = ProductDataInitialization.ProductTestData();

            //creating mock objects
            var iProductRepositoryMock = new Mock<IProductRepository>();
            var iUnitOfWorkMock = new Mock<IUnitOfWork>();
            var iServiceManagerMock = new Mock<IServiceManager>();

            //setting-up mock objects
            iProductRepositoryMock.Setup(x => x.GetProductsByCategory(It.IsAny<int>())).Returns(inputTestData);

            //Object Creation and Invocation
            ProductService productService = new ProductService(iProductRepositoryMock.Object, iUnitOfWorkMock.Object, iServiceManagerMock.Object);
            IEnumerable<Product> productData = productService.GetProductsByCategory(1);

            Assert.IsNotNull(productData);
            Assert.AreNotEqual(0, ((IEnumerable<Product>)productData).Count<Product>());
            Assert.AreEqual(10, ((IEnumerable<Product>)productData).Count<Product>());

        }
    }
}
