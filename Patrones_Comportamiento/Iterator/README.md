# Iterator — recorrido de productos

Implementa el patrón Iterator con un registro de productos de una tienda de electrónica.

- `IteratorInterface/IIterador.cs`: contrato para avanzar y reiniciar.
- `Aggregate/IListaProductos.cs`: contrato de colección.
- `Aggregate/RegistroProductos.cs`: colección concreta.
- `Aggregate/Producto.cs`: modelo de producto.
- `ConcreteIterator/IteradorProductos.cs`: iterador concreto.
- `VistaIterator.xaml(.cs)`: interfaz para agregar productos y recorrerlos.

**Prueba:** abre Iterator en el menú, presiona **Siguiente**, **Reiniciar recorrido** o **Recorrer todos**. Agrega un producto nuevo y comprueba que aparezca en el recorrido.
