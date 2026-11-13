using System;
using System.Collections.Generic;
using Patrones_Comportamiento.Iterator.Aggregate;
using Patrones_Comportamiento.Iterator.IteratorInterface;

namespace Patrones_Comportamiento.Iterator.ConcreteIterator
{
    public class IteradorProductos : IIterador<Producto>
    {
        private readonly IReadOnlyList<Producto> _productos;
        private int _posicion;
        public IteradorProductos(IReadOnlyList<Producto> productos) => _productos = productos;
        public bool TieneSiguiente() => _posicion < _productos.Count;
        public Producto Siguiente()
        {
            if (!TieneSiguiente()) throw new InvalidOperationException("No hay más productos.");
            return _productos[_posicion++];
        }
        public void Reiniciar() => _posicion = 0;
    }
}
