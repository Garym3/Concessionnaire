using System;
using System.Collections.Generic;
using Concessionnaire.StrategyOrder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConcessionnaireTest
{
    [TestClass]
    public class StrategyOrderTests
    {
        private List<Order> _orders;
        private OrderCreator _orderCreator;
        private OrderPayer _orderPayer;
        private readonly DateTime _paymentDate = new DateTime(2018, 06, 10, 23, 59, 00); 

        private void SetTestEnvironnement()
        {
            _orders = new List<Order>();
            _orderCreator = new OrderCreator(_orders);
            _orderPayer = new OrderPayer(_orders);
        }

        [TestMethod]
        public void Should_Only_Contain_2_Orders()
        {
            SetTestEnvironnement();

            _orderCreator.CreateNewOrder(new SpotOrder(0, -5));
            _orderCreator.CreateNewOrder(new ForwardOrder(1, 10, _paymentDate));
            _orderCreator.CreateNewOrder(new SpotOrder(2, 15));
            _orderCreator.CreateNewOrder(new ForwardOrder(3, -90, _paymentDate));

            _orderPayer.PayAll();

            Assert.IsTrue(_orders.Count == 2);
        }

        [TestMethod]
        public void Should_Be_Invalid_If_Amount_Is_Negative()
        {
            SetTestEnvironnement();

            var spotOrder = new SpotOrder(0, -10);
            _orderCreator.CreateNewOrder(spotOrder);
            
            Assert.IsFalse(spotOrder.IsValid());
        }

        [TestMethod]
        public void Should_Be_Invalid_If_It_Has_Already_Been_Paid()
        {
            SetTestEnvironnement();

            var spotOrder = new SpotOrder(0, 10);
            _orderCreator.CreateNewOrder(spotOrder);

            Assert.IsTrue(spotOrder.IsValid());

            _orderPayer.Pay(spotOrder);

            Assert.IsFalse(spotOrder.IsValid());
        }

        [TestMethod]
        public void Should_Be_Invalid_If_PaymentDate_Is_Inferior_Or_Equals_To_Now()
        {
            SetTestEnvironnement();

            var forwardOrder = new ForwardOrder(0, 10, _paymentDate.AddMonths(-1));
            _orderCreator.CreateNewOrder(forwardOrder);

            Assert.IsFalse(forwardOrder.IsValid());
        }
    }
}
