
using System.Collections.Generic;
using Patrones_Comportamiento.ChainOfResponsibility.Handler;

namespace Patrones_Comportamiento.ChainOfResponsibility.ConcreteHandlers
{
    public class DispensadorBebidas : Dispensador
    {
        public override string Dispensar(
            string producto,
            List<string> recorrido)
        {
            recorrido.Add("Dispensador de bebidas");

            if (producto == "Refresco")
            {
                return "Refresco entregado correctamente.";
            }

            return PasarAlSiguiente(producto, recorrido);
        }
    }
}
