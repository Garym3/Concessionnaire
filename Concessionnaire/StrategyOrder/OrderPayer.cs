using System;
using System.Collections.Generic;

namespace Concessionnaire.StrategyOrder
{
    public class OrderPayer
    {
        private static List<Order> _orders;

        public OrderPayer(List<Order> orders)
        {
            _orders = orders;
        }

        public void PayAll()
        {
            foreach (Order order in _orders)
            {
                if (!order.Pay()) continue;
                Console.WriteLine($"Order n°{order.Id} has been paid.");
            }
        }

        public void Pay(Order order)
        {
            order.Pay();
        }
    }
}
