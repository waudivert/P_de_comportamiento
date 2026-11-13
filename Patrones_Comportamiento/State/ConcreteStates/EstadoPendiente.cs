namespace Patrones_Comportamiento.State.ConcreteStates
{
    using Patrones_Comportamiento.State.Context;
    using Patrones_Comportamiento.State.StateInterface;

    public class EstadoPendiente : IEstadoPedido
    {
        public string NombreEstado => "1. PENDIENTE DE PAGO";
        public string Descripcion => "El pedido fue registrado en el carrito y espera el abono del cliente.";
        public string ColorDistintivo => "#E2A03F"; // Ámbar

        public ResultadoTransicion Pagar(Pedido pedido)
        {
            pedido.EstadoActual = new EstadoPagado();
            return new ResultadoTransicion(true, "Pago recibido con éxito (Tarjeta/Transferencia). El pedido pasa a 'PAGADO'.");
        }

        public ResultadoTransicion Enviar(Pedido pedido)
        {
            return new ResultadoTransicion(false, "Acción bloqueada: No se puede enviar un pedido sin haber recibido el pago primero.");
        }

        public ResultadoTransicion Entregar(Pedido pedido)
        {
            return new ResultadoTransicion(false, "Acción bloqueada: No se puede entregar un pedido que no ha sido pagado ni enviado.");
        }

        public ResultadoTransicion Cancelar(Pedido pedido)
        {
            pedido.EstadoActual = new EstadoCancelado();
            return new ResultadoTransicion(true, "El cliente canceló la orden antes de pagar. El pedido pasa a 'CANCELADO'.");
        }
    }
}
