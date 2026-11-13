namespace Patrones_Comportamiento.State.ConcreteStates
{
    using Patrones_Comportamiento.State.Context;
    using Patrones_Comportamiento.State.StateInterface;

    public class EstadoPagado : IEstadoPedido
    {
        public string NombreEstado => "2. PAGADO / EN ALMACÉN";
        public string Descripcion => "El dinero está confirmado. El producto está siendo empaquetado para despacho.";
        public string ColorDistintivo => "#2563EB"; // Azul

        public ResultadoTransicion Pagar(Pedido pedido)
        {
            return new ResultadoTransicion(false, "Acción redundante: El pedido ya está pagado en su totalidad.");
        }

        public ResultadoTransicion Enviar(Pedido pedido)
        {
            pedido.EstadoActual = new EstadoEnviado();
            return new ResultadoTransicion(true, "Camión de logística despachado. El pedido pasa a 'ENVIADO EN CAMINO'.");
        }

        public ResultadoTransicion Entregar(Pedido pedido)
        {
            return new ResultadoTransicion(false, "Acción bloqueada: No se puede entregar si el paquete aún no salió del almacén.");
        }

        public ResultadoTransicion Cancelar(Pedido pedido)
        {
            pedido.EstadoActual = new EstadoCancelado();
            return new ResultadoTransicion(true, "Pedido cancelado en almacén antes del despacho. Se genera solicitud de reembolso.");
        }
    }
}
