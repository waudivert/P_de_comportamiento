
using Patrones_Comportamiento.Strategy.StrategyInterface;

namespace Patrones_Comportamiento.Strategy.ConcreteStrategies
{
    public class Descuento20 : IEstrategiaDescuento
    {
        public decimal AplicarDescuento(decimal precio)
        {
            return precio * 0.80m;
        }
    }
}
