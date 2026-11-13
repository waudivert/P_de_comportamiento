using Patrones_Comportamiento.Memento.MementoState;

namespace Patrones_Comportamiento.Memento.Caretaker;

// Cuidador: guarda las versiones sin modificar su contenido.
public class HistorialNotas
{
    private readonly List<VersionNota> _versiones = [];

    public IReadOnlyList<VersionNota> Versiones => _versiones.AsReadOnly();

    public void Agregar(VersionNota version) => _versiones.Add(version);
}
