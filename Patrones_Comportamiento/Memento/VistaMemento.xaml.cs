using System.Windows;
using System.Windows.Controls;
using Patrones_Comportamiento.Memento.Caretaker;
using Patrones_Comportamiento.Memento.MementoState;
using Patrones_Comportamiento.Memento.Originator;

namespace Patrones_Comportamiento.Memento
{
    public partial class VistaMemento : UserControl
    {
        private readonly EditorNota _editor = new();
        private readonly HistorialNotas _historial = new();

        public VistaMemento()
        {
            InitializeComponent();
        }

        private void GuardarVersion_Click(object sender, RoutedEventArgs e)
        {
            _editor.Titulo = CampoTitulo.Text;
            _editor.Contenido = CampoContenido.Text;
            VersionNota version = _editor.Guardar();
            _historial.Agregar(version);
            ListaVersiones.Items.Add(version);
            ListaVersiones.SelectedItem = version;
            TextoResultado.Text = $"Versión guardada ({_historial.Versiones.Count} en el historial).";
        }

        private void RestaurarVersion_Click(object sender, RoutedEventArgs e)
        {
            if (ListaVersiones.SelectedItem is not VersionNota version)
            {
                TextoResultado.Text = "Selecciona una versión antes de restaurar.";
                return;
            }

            _editor.Restaurar(version);
            CampoTitulo.Text = _editor.Titulo;
            CampoContenido.Text = _editor.Contenido;
            TextoResultado.Text = $"Versión del {version.Fecha:dd/MM/yyyy HH:mm:ss} restaurada. Los demás puntos de guardado siguen disponibles.";
        }
    }
}
