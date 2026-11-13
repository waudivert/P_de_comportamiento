using System.Windows;
using System.Windows.Controls;
using Patrones_Comportamiento.Observer.ConcreteObservers;
using Patrones_Comportamiento.Observer.ObserverInterface;
using Patrones_Comportamiento.Observer.Subject;

namespace Patrones_Comportamiento.Observer;

public partial class VistaObserver : UserControl
{
    private readonly FichaSanitaria _ficha = new("Granja demostrativa", "BOV-001", "Luna");
    private readonly Dictionary<CheckBox, IObservadorFicha> _paneles = [];
    private readonly Dictionary<CheckBox, TextBlock> _avisos = [];
    private DateTime _dia = DateTime.Today;

    public VistaObserver()
    {
        InitializeComponent();
        FechaVacuna.SelectedDate = _dia.AddDays(1);
        FechaRetiro.SelectedDate = _dia.AddDays(3);

        RegistrarPanel(EncargadoCheck, AvisoEncargado);
        RegistrarPanel(VeterinarioCheck, AvisoVeterinario);
        RegistrarPanel(TrabajadorCheck, AvisoTrabajador);
        MostrarEstado();
    }

    private void RegistrarPanel(CheckBox check, TextBlock aviso)
    {
        var observador = new PanelRol(mensaje => aviso.Text = mensaje);
        _paneles.Add(check, observador);
        _avisos.Add(check, aviso);
        _ficha.Suscribir(observador);
    }

    private void MostrarEstado()
    {
        TextoVacuna.Text = $"Vacuna: {_ficha.EstadoVacuna}";
        TextoRetiro.Text = $"Retiro: {_ficha.EstadoRetiro}";
        TextoDia.Text = _dia.ToString("dd/MM/yyyy");
    }

    private void Suscripcion_Cambio(object sender, RoutedEventArgs e)
    {
        // Ignora los eventos de XAML antes de crear los observadores.
        if (sender is not CheckBox check || !_paneles.TryGetValue(check, out var observador))
            return;

        if (check.IsChecked == true)
        {
            _ficha.Suscribir(observador);
            _avisos[check].Text = "Esperando un nuevo cambio";
        }
        else
        {
            _ficha.Desuscribir(observador);
            _avisos[check].Text = "Avisos pausados";
        }
    }

    private void Ejecutar(Action operacion, string confirmacion)
    {
        try
        {
            operacion();
            MostrarEstado();
            TextoResultado.Text = confirmacion;
        }
        catch (ArgumentException ex)
        {
            TextoResultado.Text = ex.Message;
        }
        catch (InvalidOperationException ex)
        {
            TextoResultado.Text = ex.Message;
        }
    }

    private void ProgramarVacuna_Click(object sender, RoutedEventArgs e) => Ejecutar(() =>
    {
        if (FechaVacuna.SelectedDate is not DateTime fecha)
            throw new ArgumentException("Selecciona una fecha para la vacuna.");

        _ficha.ProgramarVacuna(CampoVacuna.Text, fecha, _dia.Date.AddHours(12));
    }, "Vacuna programada. Mira qué roles recibieron el aviso.");

    private void RegistrarAplicacion_Click(object sender, RoutedEventArgs e) => Ejecutar(
        () => _ficha.RegistrarAplicacion(_dia.Date.AddHours(12)),
        "Vacuna aplicada. Los roles activos recibieron el cambio.");

    private void IndicarRetiro_Click(object sender, RoutedEventArgs e) => Ejecutar(() =>
    {
        if (FechaRetiro.SelectedDate is not DateTime fecha)
            throw new ArgumentException("Selecciona la fecha de fin del retiro.");

        _ficha.IndicarFinRetiro(fecha.Date.AddHours(18), _dia.Date.AddHours(12));
    }, "Retiro indicado. Avanza hasta la fecha elegida para ver el aviso.");

    private void AvanzarDia_Click(object sender, RoutedEventArgs e) => Ejecutar(() =>
    {
        _dia = _dia.AddDays(1);
        _ficha.RevisarAvisos(_dia.Date.AddDays(1).AddTicks(-1));
    }, "Día actualizado. Mira los avisos de los roles activos.");
}
