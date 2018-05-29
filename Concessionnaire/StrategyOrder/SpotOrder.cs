using System;

namespace Concessionnaire.StrategyOrder
{
    public class SpotOrder : Order
    {
        public SpotOrder(int id, double amount)
        {
            Id = id;
            Amount = amount;
        }

        public override bool IsValid()
        {
            if (Amount < 0.0)
            {
                Console.WriteLine($@"/!\ Order n°{Id} has an incorrect amount.");
                if (HasBeenPayed)
                {
                    Console.WriteLine($@"/!\ Order n°{Id} has already been payed.");
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
