namespace Patrones_Comportamiento.State.Context
{
    using Patrones_Comportamiento.State.StateInterface;
    using Patrones_Comportamiento.State.ConcreteStates;

    public class Pedido
    {
        public IEstadoPedido EstadoActual { get; set; }

        public Pedido()
        {
            EstadoActual = new EstadoPendiente();
        }

        public ResultadoTransicion Pagar() => EstadoActual.Pagar(this);
        public ResultadoTransicion Enviar() => EstadoActual.Enviar(this);
        public ResultadoTransicion Entregar() => EstadoActual.Entregar(this);
        public ResultadoTransicion Cancelar() => EstadoActual.Cancelar(this);

        public void Reiniciar()
        {
            EstadoActual = new EstadoPendiente();
        }
    }
}
