namespace Patrones_Comportamiento.State.ConcreteStates
{
    using Patrones_Comportamiento.State.Context;
    using Patrones_Comportamiento.State.StateInterface;

    public class EstadoEnviado : IEstadoPedido
    {
        public string NombreEstado => "3. ENVIADO / EN TRÁNSITO";
        public string Descripcion => "El transportista tiene el paquete y se dirige al domicilio del comprador.";
        public string ColorDistintivo => "#7C3AED"; // Púrpura

        public ResultadoTransicion Pagar(Pedido pedido)
        {
            return new ResultadoTransicion(false, "Acción redundante: El pedido ya se pagó y está en camino.");
        }

        public ResultadoTransicion Enviar(Pedido pedido)
        {
            return new ResultadoTransicion(false, "Acción redundante: El pedido ya está en ruta de reparto.");
        }

        public ResultadoTransicion Entregar(Pedido pedido)
        {
            pedido.EstadoActual = new EstadoEntregado();
            return new ResultadoTransicion(true, "El cliente firmó y recibió el paquete. El pedido pasa a 'ENTREGADO'.");
        }

        public ResultadoTransicion Cancelar(Pedido pedido)
        {
            return new ResultadoTransicion(false, "Acción bloqueada: No se puede cancelar porque el paquete ya está en manos del repartidor en la calle.");
        }
    }
}
