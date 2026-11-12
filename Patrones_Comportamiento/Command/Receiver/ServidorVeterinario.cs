
using System.Collections.Generic;
using System.Linq;

using Patrones_Comportamiento.Command.Modelos;

namespace Patrones_Comportamiento.Command.Receiver
{
    public class ServidorVeterinario
    {
        public List<RegistroTratamiento> Registros { get; }
            = new List<RegistroTratamiento>();

        public void GuardarTratamiento(
            RegistroTratamiento registro)
        {
            bool existe = Registros.Any(
                r => r.Id == registro.Id);

            if (!existe)
            {
                Registros.Add(registro);
            }
        }
    }
}
