namespace Patrones_Comportamiento.State.ConcreteStates
{
    using Patrones_Comportamiento.State.Context;
    using Patrones_Comportamiento.State.StateInterface;

    public class EstadoCancelado : IEstadoPedido
    {
        public string NombreEstado => "X. PEDIDO CANCELADO";
        public string Descripcion => "La orden fue dada de baja. Ninguna operación logística está activa.";
        public string ColorDistintivo => "#DC2626"; // Rojo

        public ResultadoTransicion Pagar(Pedido pedido) => new ResultadoTransicion(false, "No se puede pagar un pedido cancelado.");
        public ResultadoTransicion Enviar(Pedido pedido) => new ResultadoTransicion(false, "No se puede enviar un pedido cancelado.");
        public ResultadoTransicion Entregar(Pedido pedido) => new ResultadoTransicion(false, "No se puede entregar un pedido cancelado.");
        public ResultadoTransicion Cancelar(Pedido pedido) => new ResultadoTransicion(false, "El pedido ya se encuentra cancelado.");
    }
}
