using Patrones_Comportamiento.Mediator.MediatorInterface;

namespace Patrones_Comportamiento.Mediator.Colleagues
{
    public class Almacen : ComponentePedido
    {
        public Almacen(IMediadorPedidos mediador) : base(mediador) { }
        public string PedidoActual { get; private set; } = "Ninguno";
        public void RecibirPedido(string pedido) => PedidoActual = pedido;
        public void Preparar(string articulo) => Mediador.Notificar("Almacen", "producto_preparado", articulo);
        public void RecibirAviso(string mensaje) => UltimoAviso = mensaje;
        public string UltimoAviso { get; private set; } = "Sin avisos";
    }
}
