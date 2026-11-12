
using System.Collections.Generic;
using Patrones_Comportamiento.ChainOfResponsibility.Handler;

namespace Patrones_Comportamiento.ChainOfResponsibility.ConcreteHandlers
{
    public class DispensadorDulces : Dispensador
    {
        public override string Dispensar(
            string producto,
            List<string> recorrido)
        {
            recorrido.Add("Dispensador de dulces");

            if (producto == "Chocolate")
            {
                return "Chocolate entregado correctamente.";
            }

            return PasarAlSiguiente(producto, recorrido);
        }
    }
}
