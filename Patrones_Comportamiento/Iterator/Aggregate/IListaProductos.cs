using Patrones_Comportamiento.Iterator.IteratorInterface;

namespace Patrones_Comportamiento.Iterator.Aggregate
{
    public interface IListaProductos
    {
        IIterador<Producto> CrearIterador();
    }
}
