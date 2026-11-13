namespace Patrones_Comportamiento.Memento.MementoState;

// Memento: conserva una versión inmutable de la nota.
public sealed record VersionNota(string Titulo, string Contenido, DateTime Fecha)
{
    public override string ToString() => $"{Fecha:HH:mm:ss} · {Titulo}";
}
