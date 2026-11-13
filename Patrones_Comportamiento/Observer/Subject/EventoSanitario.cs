namespace Patrones_Comportamiento.Observer.Subject;

public sealed record EventoSanitario(DateTime Fecha, string Granja, string Identificacion,
    string Tipo, string Detalle);
