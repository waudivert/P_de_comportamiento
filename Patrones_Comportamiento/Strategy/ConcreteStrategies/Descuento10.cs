
using Patrones_Comportamiento.Strategy.StrategyInterface;

namespace Patrones_Comportamiento.Strategy.ConcreteStrategies
{
    public class Descuento10 : IEstrategiaDescuento
    {
        public decimal AplicarDescuento(decimal precio)
        {
            return precio * 0.90m;
        }
    }
}
