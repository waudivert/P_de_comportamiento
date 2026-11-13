# Mediator — coordinación de pedidos

Implementa el patrón Mediator para coordinar Atención al cliente, Almacen y Envios sin referencias directas entre los componentes.

- `MediatorInterface/IMediadorPedidos.cs`: contrato de notificación.
- `ConcreteMediator/MediadorPedidos.cs`: coordinación central.
- `Colleagues/ComponentePedido.cs`: componente base.
- `Colleagues/AtencionCliente.cs`, `Almacen.cs`, `Envios.cs`: componentes.
- `VistaMediator.xaml(.cs)`: interfaz interactiva.

**Prueba:** registra un pedido, prepara un producto y confirma el envío. Observa los eventos en el historial y reinicia para repetir.
