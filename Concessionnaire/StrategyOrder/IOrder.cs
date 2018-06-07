
namespace Concessionnaire.StrategyOrder
{
    public interface IOrder
    {
        bool Pay();

        bool IsValid();
    }
}
