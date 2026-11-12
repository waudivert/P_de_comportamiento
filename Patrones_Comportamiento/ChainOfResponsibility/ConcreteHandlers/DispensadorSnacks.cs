
using System.Collections.Generic;
using Patrones_Comportamiento.ChainOfResponsibility.Handler;

namespace Patrones_Comportamiento.ChainOfResponsibility.ConcreteHandlers
{
    public class DispensadorSnacks : Dispensador
    {
        public override string Dispensar(
            string producto,
            List<string> recorrido)
        {
            recorrido.Add("Dispensador de snacks");

            if (producto == "Papas fritas")
            {
                return "Papas fritas entregadas correctamente.";
            }

            return PasarAlSiguiente(producto, recorrido);
        }
    }
}
