namespace Patrones_Comportamiento.Iterator.IteratorInterface
{
    public interface IIterador<T>
    {
        bool TieneSiguiente();
        T Siguiente();
        void Reiniciar();
    }
}
