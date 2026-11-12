
using System.Collections.Generic;

namespace Patrones_Comportamiento.ChainOfResponsibility.Handler
{
    public abstract class Dispensador
    {
        protected Dispensador? siguiente;

        public void EstablecerSiguiente(Dispensador dispensador)
        {
            siguiente = dispensador;
        }

        public abstract string Dispensar(
            string producto,
            List<string> recorrido);

        protected string PasarAlSiguiente(
            string producto,
            List<string> recorrido)
        {
            if (siguiente != null)
            {
                return siguiente.Dispensar(producto, recorrido);
            }

            return "Producto no disponible.";
        }
    }
}
