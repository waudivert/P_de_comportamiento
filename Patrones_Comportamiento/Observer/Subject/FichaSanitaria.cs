using Patrones_Comportamiento.Observer.ObserverInterface;

namespace Patrones_Comportamiento.Observer.Subject;

// Sujeto Observer: guarda la ficha y avisa a quienes están suscritos.
public sealed class FichaSanitaria(string granja, string identificacion, string nombre)
{
    private readonly List<IObservadorFicha> _observadores = [];
    private string? _vacuna;
    private DateTime? _fechaVacuna;
    private bool _vacunaAplicada;
    private bool _vacunaVencida;
    private DateTime? _finRetiro;
    private bool _retiroCumplido;

    public string Granja { get; } = granja;
    public string Identificacion { get; } = identificacion;
    public string Nombre { get; } = nombre;
    public string EstadoVacuna => _vacuna is null ? "Sin vacuna programada" :
        _vacunaAplicada ? $"{_vacuna}: realizada" :
        _vacunaVencida ? $"{_vacuna}: vencida desde {_fechaVacuna:dd/MM/yyyy}" :
        $"{_vacuna}: pendiente para {_fechaVacuna:dd/MM/yyyy}";
    public string EstadoRetiro => _finRetiro is null ? "Sin retiro registrado" :
        _retiroCumplido ? $"Plazo cumplido según fecha registrada ({_finRetiro:dd/MM/yyyy HH:mm})" :
        $"En retiro hasta {_finRetiro:dd/MM/yyyy HH:mm}";

    public void Suscribir(IObservadorFicha observador)
    {
        if (!_observadores.Contains(observador))
            _observadores.Add(observador);
    }

    public void Desuscribir(IObservadorFicha observador) => _observadores.Remove(observador);

    public void ProgramarVacuna(string vacuna, DateTime fecha, DateTime hoy)
    {
        if (string.IsNullOrWhiteSpace(vacuna))
            throw new ArgumentException("Indica el nombre de la vacuna.");

        if (_vacuna is not null && !_vacunaAplicada)
            throw new InvalidOperationException("Primero registra la aplicación de la vacuna pendiente.");

        _vacuna = vacuna.Trim();
        _fechaVacuna = fecha.Date;
        _vacunaAplicada = false;
        _vacunaVencida = false;
        Notificar(hoy, "Vacuna pendiente", $"{_vacuna} programada para {_fechaVacuna:dd/MM/yyyy} por el veterinario.");
        RevisarAvisos(hoy);
    }

    public void RegistrarAplicacion(DateTime fecha)
    {
        if (_vacuna is null || _vacunaAplicada)
            throw new InvalidOperationException("No hay una vacuna pendiente para registrar su aplicación.");

        _vacunaAplicada = true;
        Notificar(fecha, "Vacuna realizada", $"{_vacuna} aplicada por el trabajador el {fecha:dd/MM/yyyy}.");
    }

    // El veterinario indica el fin del retiro; aquí no se calcula el plazo.
    public void IndicarFinRetiro(DateTime fin, DateTime hoy)
    {
        if (fin <= hoy)
            throw new ArgumentException("El fin del retiro debe ser posterior a la fecha y hora de referencia.");

        _finRetiro = fin;
        _retiroCumplido = false;
        Notificar(hoy, "Retiro activo", $"Fin indicado por el veterinario: {fin:dd/MM/yyyy HH:mm}. No usar la leche durante el retiro.");
    }

    public void RevisarAvisos(DateTime fecha)
    {
        if (_vacuna is not null && !_vacunaAplicada && !_vacunaVencida && _fechaVacuna < fecha.Date)
        {
            _vacunaVencida = true;
            Notificar(fecha, "Vacuna vencida", $"{_vacuna} sigue pendiente desde {_fechaVacuna:dd/MM/yyyy}.");
        }

        if (_finRetiro is not null && !_retiroCumplido && fecha >= _finRetiro)
        {
            _retiroCumplido = true;
            Notificar(fecha, "Plazo de retiro cumplido",
                $"Llegó la fecha indicada ({_finRetiro:dd/MM/yyyy HH:mm}). Verificar indicaciones antes de utilizar la leche.");
        }
    }

    // Envía el cambio a cada observador activo mediante la interfaz.
    private void Notificar(DateTime fecha, string tipo, string detalle)
    {
        var evento = new EventoSanitario(fecha, Granja, Identificacion, tipo, detalle);
        foreach (var observador in _observadores.ToArray())
            observador.Actualizar(evento);
    }
}
