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
                return false;
            }
            if (HasBeenPaid)
            {
                Console.WriteLine($@"/!\ Order n°{Id} has already been paid.");
                return false;
            }

            return true;
        }

        public override bool Pay()
        {
            if (!IsValid()) return false;

            HasBeenPaid = true;
            return true;
        }
    }
}
