
namespace Concessionnaire.StrategyOrder
{
    public abstract class Order
    {
        protected double Amount = 0.0;
        protected bool HasBeenPayed = false;
        public int Id;
    
        public abstract void Pay();

        public abstract bool IsValid();
    }
}
