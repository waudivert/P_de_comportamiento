namespace Patrones_Comportamiento.State.ConcreteStates
{
    using Patrones_Comportamiento.State.Context;
    using Patrones_Comportamiento.State.StateInterface;

    public class EstadoEntregado : IEstadoPedido
    {
        public string NombreEstado => "4. ENTREGADO (FINALIZADO)";
        public string Descripcion => "El ciclo del pedido concluyó exitosamente. Cliente conforme.";
        public string ColorDistintivo => "#16A34A"; // Verde

        public ResultadoTransicion Pagar(Pedido pedido) => new ResultadoTransicion(false, "El pedido ya terminó con entrega confirmada.");
        public ResultadoTransicion Enviar(Pedido pedido) => new ResultadoTransicion(false, "El pedido ya fue entregado.");
        public ResultadoTransicion Entregar(Pedido pedido) => new ResultadoTransicion(false, "El pedido ya fue entregado previamente.");
        public ResultadoTransicion Cancelar(Pedido pedido) => new ResultadoTransicion(false, "No se puede cancelar una compra ya recibida y finalizada.");
    }
}
