namespace Patrones_Comportamiento.State.StateInterface
{
    using Patrones_Comportamiento.State.Context;

    public interface IEstadoPedido
    {
        string NombreEstado { get; }
        string Descripcion { get; }
        string ColorDistintivo { get; }

        ResultadoTransicion Pagar(Pedido pedido);
        ResultadoTransicion Enviar(Pedido pedido);
        ResultadoTransicion Entregar(Pedido pedido);
        ResultadoTransicion Cancelar(Pedido pedido);
    }

    public class ResultadoTransicion
    {
        public bool EsValida { get; }
        public string Mensaje { get; }

        public ResultadoTransicion(bool esValida, string mensaje)
        {
            EsValida = esValida;
            Mensaje = mensaje;
        }
    }
}
