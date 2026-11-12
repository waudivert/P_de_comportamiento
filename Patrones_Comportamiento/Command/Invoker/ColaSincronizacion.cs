
using System.Collections.Generic;

using Patrones_Comportamiento.Command.CommandInterface;

namespace Patrones_Comportamiento.Command.Invoker
{
    public class ColaSincronizacion
    {
        private readonly List<IComando> pendientes
            = new List<IComando>();

        public IReadOnlyList<IComando> Pendientes =>
            pendientes.AsReadOnly();

        public void Agregar(IComando comando)
        {
            pendientes.Add(comando);
        }

        public int Sincronizar(bool hayConexion)
        {
            if (!hayConexion)
            {
                return 0;
            }

            int completados = 0;

            // Se ejecutan en el orden registrado.
            while (pendientes.Count > 0)
            {
                IComando comando = pendientes[0];

                comando.Ejecutar();

                // Solo quitar si se ejecutó correctamente.
                pendientes.RemoveAt(0);

                completados++;
            }

            return completados;
        }
    }
}
