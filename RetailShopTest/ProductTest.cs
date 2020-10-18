using RetailShop.BL.Models;
using RetailShop.BL.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RetailShop.BL.IRepo;
using System;

namespace RetailShop.Tests
{
    [TestClass]
    public class ProductTest
    {
        private readonly Product _defaultPostObject;
        private readonly ProductService _productService;
        private readonly Mock<IProductRepo> _productRepo;

        public ProductTest()
        {
            _defaultPostObject = new Product();
            _productRepo = new Mock<IProductRepo>();
            _productService = new ProductService(_productRepo.Object);
        }

        [TestMethod]
        public void AddProduct_Returns_Int_When_Add()
        {
            //Arrange
            _productRepo.Setup(er => er.AddProduct(_defaultPostObject)).Returns(It.IsAny<int>());

            //Act
            var result = _productService.AddProduct(_defaultPostObject);

            //Assert
            Assert.AreEqual(It.IsAny<int>(), result);
        }

        [TestMethod]
        public void AddProduct_RethrowsException()
        {
            //Arrange
            _productRepo.Setup(o => o.AddProduct(_defaultPostObject)).Throws(new NotImplementedException());

            //Act //Assert
            Assert.ThrowsException<NotImplementedException>(() => _productService.AddProduct(_defaultPostObject));
        }

        [TestMethod]
        public void UpdateProduct_Returns_Int_When_Add()
        {
            //Arrange
            _productRepo.Setup(er => er.UpdateProduct(_defaultPostObject)).Returns(It.IsAny<int>());

            //Act
            var result = _productService.UpdateProduct(_defaultPostObject);

            //Assert
            Assert.AreEqual(It.IsAny<int>(), result);
        }

        [TestMethod]
        public void UpdateProduct_RethrowsException()
        {
            //Arrange
            _productRepo.Setup(o => o.UpdateProduct(_defaultPostObject)).Throws(new NotImplementedException());

            //Act //Assert
            Assert.ThrowsException<NotImplementedException>(() => _productService.UpdateProduct(_defaultPostObject));
        }

        [TestMethod]
        public void DeleteProduct_RethrowsException()
        {
            //Arrange 
            int id = It.IsAny<int>();

            //Act
            _productRepo.Setup(o => o.DeleteProduct(id)).Throws(new NotImplementedException());

            //Assert
            Assert.ThrowsException<NotImplementedException>(() => _productService.DeleteProduct(id));
        }

        [TestMethod]
        public void DeleteIndividual_Calls_DeleteIndividual()
        {
            //Arrange 
            int id = It.IsAny<int>();

            //Act
            _productService.DeleteProduct(id);

            //Assert
            _productRepo.Verify(o => o.DeleteProduct(id));
        }

    }
}
