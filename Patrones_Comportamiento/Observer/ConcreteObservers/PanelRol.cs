using Patrones_Comportamiento.Observer.ObserverInterface;
using Patrones_Comportamiento.Observer.Subject;

namespace Patrones_Comportamiento.Observer.ConcreteObservers;

// Observador concreto: muestra el último aviso recibido por un rol.
public sealed class PanelRol(Action<string> mostrarAviso) : IObservadorFicha
{
    public void Actualizar(EventoSanitario evento) => mostrarAviso(
        $"{evento.Tipo}: {evento.Detalle}");
}
