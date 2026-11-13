using Patrones_Comportamiento.Mediator.MediatorInterface;

namespace Patrones_Comportamiento.Mediator.Colleagues
{
    public class Envios : ComponentePedido
    {
        public Envios(IMediadorPedidos mediador) : base(mediador) { }
        public string PaquetePendiente { get; private set; } = "Ninguno";
        public void RecibirPaquete(string articulo) => PaquetePendiente = articulo;
        public void EnviarPaquete() => Mediador.Notificar("Envios", "paquete_enviado", PaquetePendiente);
        public void LimpiarPaquete() => PaquetePendiente = "Ninguno";
    }
}
