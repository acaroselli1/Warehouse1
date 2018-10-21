using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Warehouse1.Entities;
using Warehouse1.Business;
using NSubstitute;
using Warehouse1.Data;

namespace Warehouse1.Business.Test
{
    [TestClass]
    public class OrderServiceTests
    {
        [TestMethod]
        public void CloseOrder_Can_Not_Close_Already_Closed_Order()
        {
            //arrange
            var order = new Order
            {
                Id = 1,
                ClosedAt = DateTimeOffset.Now,

            };

            var mockOrderRepo = Substitute.For<IOrderRepo>();

            mockOrderRepo.GetOrderById(order.Id).Returns(order);


            var orderService = new OrderService(mockOrderRepo);
            //act

            try
            {

                var expectedOrder = orderService.CloseOrder(order);

            }
            
            catch (Exception ex)
            {
                {
                    Assert.AreEqual("Order already closed.", ex.Message);
                    return;
                }

            }
            //assert
            Assert.Fail("Shouldn't have gotten here.");



        }
        [TestMethod]
        public void CloseOrder_Can_Close_Order_Not_Already_Closed()
        {
            //arrange
            var userOrder = new Order
            {
                Id = 1
            };

            var mockOrderRepo = Substitute.For<IOrderRepo>();

            mockOrderRepo.GetOrderById(userOrder.Id).Returns(new Order
            {
                Id = 1,
                ClosedAt = null

            });


            var orderService = new OrderService(mockOrderRepo);

            //act
           


            var expectedOrder = orderService.CloseOrder(userOrder);

            //assert


            Assert.IsNotNull(expectedOrder.ClosedAt);

            mockOrderRepo.Received(1).GetOrderById(userOrder.Id);

            mockOrderRepo.Received(1).GetOrderById(userOrder.Id);
            mockOrderRepo.ReceivedWithAnyArgs(1).UpdateOrder(expectedOrder);
        }
    }

}

