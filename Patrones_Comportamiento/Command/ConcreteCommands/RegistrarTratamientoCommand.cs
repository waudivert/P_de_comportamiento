
using Patrones_Comportamiento.Command.CommandInterface;
using Patrones_Comportamiento.Command.Modelos;
using Patrones_Comportamiento.Command.Receiver;

namespace Patrones_Comportamiento.Command.ConcreteCommands
{
    public class RegistrarTratamientoCommand : IComando
    {
        private readonly ServidorVeterinario servidor;

        private readonly RegistroTratamiento registro;

        public string Descripcion =>
            registro.Arete + " - " + registro.Tratamiento;

        public RegistrarTratamientoCommand(
            ServidorVeterinario servidor,
            RegistroTratamiento registro)
        {
            this.servidor = servidor;
            this.registro = registro;
        }

        public void Ejecutar()
        {
            servidor.GuardarTratamiento(registro);
        }
    }
}
