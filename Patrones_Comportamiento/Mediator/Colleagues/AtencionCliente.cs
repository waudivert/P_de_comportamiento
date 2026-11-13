using Patrones_Comportamiento.Mediator.MediatorInterface;

namespace Patrones_Comportamiento.Mediator.Colleagues
{
    public class AtencionCliente : ComponentePedido
    {
        public AtencionCliente(IMediadorPedidos mediador) : base(mediador) { }
        public void RegistrarPedido(string pedido) => Mediador.Notificar("Atención al cliente", "pedido_registrado", pedido);
        public void RecibirAviso(string mensaje) { UltimoAviso = mensaje; }
        public string UltimoAviso { get; private set; } = "Sin avisos";
    }
}
