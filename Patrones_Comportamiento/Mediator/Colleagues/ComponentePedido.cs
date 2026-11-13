using Patrones_Comportamiento.Mediator.MediatorInterface;

namespace Patrones_Comportamiento.Mediator.Colleagues
{
    public abstract class ComponentePedido
    {
        protected readonly IMediadorPedidos Mediador;
        protected ComponentePedido(IMediadorPedidos mediador) => Mediador = mediador;
    }
}
