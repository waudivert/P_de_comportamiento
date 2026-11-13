using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Patrones_Comportamiento.State.Context;
using Patrones_Comportamiento.State.StateInterface;

namespace Patrones_Comportamiento.State
{
    public partial class VistaState : UserControl
    {
        private readonly Pedido pedido;

        public VistaState()
        {
            InitializeComponent();
            pedido = new Pedido();
            RefrescarVista("Orden iniciada. Puedes intentar 'Pagar' o 'Enviar' para probar el comportamiento.");
        }

        private void RefrescarVista(string mensaje, bool? esValida = null)
        {
            TxtBadgeEstado.Text = pedido.EstadoActual.NombreEstado;
            TxtDescripcionEstado.Text = pedido.EstadoActual.Descripcion;

            try
            {
                BordeBadgeEstado.Background = (Brush)new BrushConverter().ConvertFromString(pedido.EstadoActual.ColorDistintivo)!;
            }
            catch
            {
                BordeBadgeEstado.Background = (Brush)new BrushConverter().ConvertFromString("#267453")!;
            }

            TxtUltimaRespuesta.Text = mensaje;

            string hora = DateTime.Now.ToString("HH:mm:ss");
            string icono = esValida.HasValue ? (esValida.Value ? "✔ Transición:" : "⛔ Bloqueado:") : "ℹ Info:";
            ListaHistorial.Items.Insert(0, $"[{hora}] {icono} {mensaje}");
        }

        private void BtnPagar_Click(object sender, RoutedEventArgs e)
        {
            ResultadoTransicion res = pedido.Pagar();
            RefrescarVista(res.Mensaje, res.EsValida);
        }

        private void BtnEnviar_Click(object sender, RoutedEventArgs e)
        {
            ResultadoTransicion res = pedido.Enviar();
            RefrescarVista(res.Mensaje, res.EsValida);
        }

        private void BtnEntregar_Click(object sender, RoutedEventArgs e)
        {
            ResultadoTransicion res = pedido.Entregar();
            RefrescarVista(res.Mensaje, res.EsValida);
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            ResultadoTransicion res = pedido.Cancelar();
            RefrescarVista(res.Mensaje, res.EsValida);
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            pedido.Reiniciar();
            ListaHistorial.Items.Clear();
            RefrescarVista("Pedido reiniciado a estado inicial 'Pendiente de Pago'.");
        }
    }
}
