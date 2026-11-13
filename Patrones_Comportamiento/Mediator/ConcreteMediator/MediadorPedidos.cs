using System;
using Patrones_Comportamiento.Mediator.Colleagues;
using Patrones_Comportamiento.Mediator.MediatorInterface;

namespace Patrones_Comportamiento.Mediator.ConcreteMediator
{
    public class MediadorPedidos : IMediadorPedidos
    {
        public AtencionCliente AtencionCliente { get; }
        public Almacen Almacen { get; }
        public Envios Envios { get; }
        public event Action<string>? MensajeGenerado;

        public MediadorPedidos()
        {
            AtencionCliente = new AtencionCliente(this);
            Almacen = new Almacen(this);
            Envios = new Envios(this);
        }

        public void Notificar(string emisor, string evento, string detalle)
        {
            switch (evento)
            {
                case "pedido_registrado":
                    Almacen.RecibirPedido(detalle);
                    Envios.LimpiarPaquete();
                    Almacen.RecibirAviso($"Preparar pedido de {detalle}");
                    MensajeGenerado?.Invoke($"{emisor} → Mediador → Almacen: preparar pedido de {detalle}.");
                    break;
                case "producto_preparado":
                    Envios.RecibirPaquete(detalle);
                    MensajeGenerado?.Invoke($"{emisor} → Mediador → Envios: preparar {detalle}.");
                    break;
                case "paquete_enviado":
                    AtencionCliente.RecibirAviso($"Paquete enviado: {detalle}");
                    Almacen.RecibirAviso($"Envío confirmado: {detalle}");
                    Envios.LimpiarPaquete();
                    MensajeGenerado?.Invoke($"{emisor} → Mediador → Atención al cliente y Almacen: {detalle} enviado.");
                    break;
            }
        }
    }
}
