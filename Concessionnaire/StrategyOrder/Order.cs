
namespace Concessionnaire.StrategyOrder
{
    public abstract class Order
    {
        protected double Amount = 0.0;
        protected bool HasBeenPaid = false;
        public int Id;

        public abstract bool Pay();
        public abstract bool IsValid();
    }
}
