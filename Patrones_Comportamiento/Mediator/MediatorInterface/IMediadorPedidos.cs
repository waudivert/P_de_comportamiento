namespace Patrones_Comportamiento.Mediator.MediatorInterface
{
    public interface IMediadorPedidos
    {
        void Notificar(string emisor, string evento, string detalle);
    }
}
