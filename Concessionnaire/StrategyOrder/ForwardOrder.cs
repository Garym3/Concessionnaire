using System;

namespace Concessionnaire.StrategyOrder
{
    public class ForwardOrder : Order
    {
        private readonly DateTime _paymentDate;

        public ForwardOrder(int id, double amount, DateTime paymentDate)
        {
            Id = id;
            Amount = amount;
            _paymentDate = paymentDate;
        }

        public override bool IsValid()
        {
            if (Amount < 0.0)
            {
                Console.WriteLine($@"/!\ Order n°{Id} has an incorrect amount.");
                if (HasBeenPayed)
                {
                    Console.WriteLine($@"/!\ Order n°{Id} has already been payed.");
                    if (DateTime.Now >= _paymentDate)
                    {
                        Console.WriteLine($@"/!\ Order n°{Id} has already past by its payment date.");
                        return false;
                    }
                    return false;
                }
                return false;
            }

            return true;
        }

        public override void Pay()
        {
            if (!IsValid()) return;

            HasBeenPayed = true;
        }
    }
}
