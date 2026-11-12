
using Patrones_Comportamiento.Strategy.StrategyInterface;

namespace Patrones_Comportamiento.Strategy.Context
{
    public class CalculadoraPrecios
    {
        private IEstrategiaDescuento estrategia;

        public CalculadoraPrecios(
            IEstrategiaDescuento estrategia)
        {
            this.estrategia = estrategia;
        }

        public void CambiarEstrategia(
            IEstrategiaDescuento nuevaEstrategia)
        {
            estrategia = nuevaEstrategia;
        }

        public decimal Calcular(decimal precio)
        {
            return estrategia.AplicarDescuento(precio);
        }
    }
}
