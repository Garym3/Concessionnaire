using System;
using System.Collections.Generic;

namespace Concessionnaire.StrategyOrder
{
    public class OrderCreator
    {
        private static List<Order> _orders;

        public OrderCreator(List<Order> orders)
        {
            _orders = orders;
        }

        public void CreateNewOrder(Order order)
        {
            if (!order.IsValid()) return;

            _orders.Add(order);
            Console.WriteLine($"Order n°{order.Id} has been added to the order list.");
        }
    }
}
