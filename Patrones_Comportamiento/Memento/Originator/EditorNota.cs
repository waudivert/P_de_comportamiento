using Patrones_Comportamiento.Memento.MementoState;

namespace Patrones_Comportamiento.Memento.Originator;

// Originador: crea una copia de su estado y puede restaurarla.
public class EditorNota
{
    public string Titulo { get; set; } = "Mi nota";
    public string Contenido { get; set; } = "";

    public VersionNota Guardar() => new(Titulo, Contenido, DateTime.Now);

    public void Restaurar(VersionNota version)
    {
        Titulo = version.Titulo;
        Contenido = version.Contenido;
    }
}
