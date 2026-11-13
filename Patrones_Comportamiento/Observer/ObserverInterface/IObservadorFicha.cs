using Patrones_Comportamiento.Observer.Subject;

namespace Patrones_Comportamiento.Observer.ObserverInterface;

// Todos los observadores implementan este método para recibir cambios de la ficha.
public interface IObservadorFicha
{
    void Actualizar(EventoSanitario evento);
}
