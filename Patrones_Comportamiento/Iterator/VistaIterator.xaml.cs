using System;
using System.Windows;
using System.Windows.Controls;
using Patrones_Comportamiento.Iterator.Aggregate;
using Patrones_Comportamiento.Iterator.IteratorInterface;

namespace Patrones_Comportamiento.Iterator
{
    public partial class VistaIterator : UserControl
    {
        private readonly RegistroProductos _registro = new();
        private IIterador<Producto> _iterador;
        private int _recorridos;

        public VistaIterator()
        {
            InitializeComponent();
            _registro.Agregar(new Producto("ELE-001", "Arduino UNO", "Electrónica"));
            _registro.Agregar(new Producto("ACC-002", "Cable USB", "Accesorios"));
            _registro.Agregar(new Producto("HER-003", "Multímetro", "Herramientas"));
            _iterador = _registro.CrearIterador();
            ActualizarLista();
        }

        private void ActualizarLista()
        {
            ListaProductos.Items.Clear();
            var copia = _registro.CrearIterador();
            while (copia.TieneSiguiente()) ListaProductos.Items.Add(copia.Siguiente().ToString());
            TxtCantidad.Text = $"Productos registrados: {_registro.Cantidad}";
            TxtProgreso.Text = $"Recorridos: {_recorridos} / {_registro.Cantidad}";
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            string codigo = TxtCodigo.Text.Trim();
            string nombre = TxtNombre.Text.Trim();
            string categoria = (CmbCategoria.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "Electrónica";
            if (string.IsNullOrWhiteSpace(codigo) || string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Ingresa el código y el nombre del producto.");
                return;
            }
            var verificar = _registro.CrearIterador();
            while (verificar.TieneSiguiente())
            {
                if (string.Equals(verificar.Siguiente().Codigo, codigo, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Ese código ya está registrado.");
                    return;
                }
            }
            _registro.Agregar(new Producto(codigo, nombre, categoria));
            Reiniciar();
            ActualizarLista();
            TxtActual.Text = "Producto agregado. Recorrido reiniciado.";
        }

        private void Reiniciar()
        {
            _iterador = _registro.CrearIterador();
            _recorridos = 0;
            ListaProductos.SelectedIndex = -1;
        }

        private void BtnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            if (!_iterador.TieneSiguiente())
            {
                TxtActual.Text = "Fin del recorrido. Pulsa Reiniciar para comenzar nuevamente.";
                return;
            }
            var producto = _iterador.Siguiente();
            ListaProductos.SelectedIndex = _recorridos++;
            ListaProductos.ScrollIntoView(ListaProductos.SelectedItem);
            TxtActual.Text = $"Producto actual: {producto}";
            TxtProgreso.Text = $"Recorridos: {_recorridos} / {_registro.Cantidad}";
        }

        private void BtnReiniciar_Click(object sender, RoutedEventArgs e)
        {
            Reiniciar();
            TxtActual.Text = "Recorrido reiniciado. Presiona Siguiente.";
            TxtProgreso.Text = $"Recorridos: 0 / {_registro.Cantidad}";
        }

        private void BtnTodos_Click(object sender, RoutedEventArgs e)
        {
            Reiniciar();
            var resultado = new System.Text.StringBuilder();
            while (_iterador.TieneSiguiente())
            {
                resultado.AppendLine(_iterador.Siguiente().ToString());
                _recorridos++;
            }
            ListaProductos.SelectedIndex = _registro.Cantidad - 1;
            TxtActual.Text = resultado.ToString();
            TxtProgreso.Text = $"Recorridos: {_recorridos} / {_registro.Cantidad}";
        }
    }
}
