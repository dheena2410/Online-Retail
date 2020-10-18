using RetailShop.BL.Models;
using RetailShop.BL.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RetailShop.BL.IRepo;
using System;

namespace RetailShop.Tests
{
    [TestClass]
    public class OrderTest
    {
        private readonly Order _defaultPostObject;
        private readonly OrderService _orderService;
        private readonly Mock<IOrderRepo> _orderRepo;

        public OrderTest()
        {
            _defaultPostObject = new Order();
            _orderRepo = new Mock<IOrderRepo>();
            _orderService = new OrderService(_orderRepo.Object);
        }

        [TestMethod]
        public void PlaceOrder_Returns_Int_When_Add()
        {
            //Arrange
            _orderRepo.Setup(er => er.PlaceOrder(_defaultPostObject)).Returns(It.IsAny<int>());

            //Act
            var result = _orderService.PlaceOrder(_defaultPostObject);

            //Assert
            Assert.AreEqual(It.IsAny<int>(), result);
        }

        [TestMethod]
        public void PlaceOrder_RethrowsException()
        {
            //Arrange
            _orderRepo.Setup(o => o.PlaceOrder(_defaultPostObject)).Throws(new NotImplementedException());

            //Act //Assert
            Assert.ThrowsException<NotImplementedException>(() => _orderService.PlaceOrder(_defaultPostObject));
        }

        [TestMethod]
        public void CancelOrder_RethrowsException()
        {
            //Arrange 
            int id = It.IsAny<int>();

            //Act
            _orderRepo.Setup(o => o.CancelOrder(id)).Throws(new NotImplementedException());

            //Assert
            Assert.ThrowsException<NotImplementedException>(() => _orderService.CancelOrder(id));
        }

        [TestMethod]
        public void CancelOrder_Calls_DeleteIndividual()
        {
            //Arrange 
            int id = It.IsAny<int>();

            //Act
            _orderService.CancelOrder(id);

            //Assert
            _orderRepo.Verify(o => o.CancelOrder(id));
        }

    }
}
