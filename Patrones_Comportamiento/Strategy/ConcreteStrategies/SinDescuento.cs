
using Patrones_Comportamiento.Strategy.StrategyInterface;

namespace Patrones_Comportamiento.Strategy.ConcreteStrategies
{
    public class SinDescuento : IEstrategiaDescuento
    {
        public decimal AplicarDescuento(decimal precio)
        {
            return precio;
        }
    }
}
