using System.Collections.Generic;
using Patrones_Comportamiento.Iterator.ConcreteIterator;
using Patrones_Comportamiento.Iterator.IteratorInterface;

namespace Patrones_Comportamiento.Iterator.Aggregate
{
    public class RegistroProductos : IListaProductos
    {
        private readonly List<Producto> _productos = new();
        public int Cantidad => _productos.Count;
        public void Agregar(Producto producto) => _productos.Add(producto);
        public IIterador<Producto> CrearIterador() => new IteradorProductos(_productos);
    }
}
