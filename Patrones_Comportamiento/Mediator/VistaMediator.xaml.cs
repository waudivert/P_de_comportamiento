using System.Windows;
using System.Windows.Controls;
using Patrones_Comportamiento.Mediator.ConcreteMediator;

namespace Patrones_Comportamiento.Mediator
{
    public partial class VistaMediator : UserControl
    {
        private MediadorPedidos _mediador = null!;

        public VistaMediator()
        {
            InitializeComponent();
            Reiniciar();
        }

        private void Reiniciar()
        {
            _mediador = new MediadorPedidos();
            _mediador.MensajeGenerado += mensaje =>
            {
                ListaMensajes.Items.Add(mensaje);
                ListaMensajes.ScrollIntoView(ListaMensajes.Items[ListaMensajes.Items.Count - 1]);
                ActualizarEstado();
            };
            ListaMensajes.Items.Clear();
            ActualizarEstado();
        }

        private void ActualizarEstado()
        {
            TxtPedidoActual.Text = $"Pedido: {_mediador.Almacen.PedidoActual}";
            TxtPaquete.Text = $"Paquete: {_mediador.Envios.PaquetePendiente}";
            TxtAviso.Text = $"Atención al cliente: {_mediador.AtencionCliente.UltimoAviso} | Almacen: {_mediador.Almacen.UltimoAviso}";
        }

        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            string pedido = TxtNuevoPedido.Text.Trim();
            if (string.IsNullOrWhiteSpace(pedido))
            {
                MessageBox.Show("Ingresa un pedido.");
                return;
            }
            _mediador.AtencionCliente.RegistrarPedido(pedido);
        }

        private void BtnPreparar_Click(object sender, RoutedEventArgs e)
        {
            if (_mediador.Almacen.PedidoActual == "Ninguno")
            {
                MessageBox.Show("Primero registra un pedido en atención al cliente.");
                return;
            }
            string articulo = (CmbArticulo.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "Arduino UNO";
            _mediador.Almacen.Preparar(articulo);
        }

        private void BtnEntregar_Click(object sender, RoutedEventArgs e)
        {
            if (_mediador.Envios.PaquetePendiente == "Ninguno")
            {
                MessageBox.Show("Aún no hay un paquete pendiente.");
                return;
            }
            _mediador.Envios.EnviarPaquete();
        }

        private void BtnReiniciar_Click(object sender, RoutedEventArgs e) => Reiniciar();
    }
}
