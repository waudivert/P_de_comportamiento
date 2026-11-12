
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using Patrones_Comportamiento.ChainOfResponsibility.Handler;
using Patrones_Comportamiento.ChainOfResponsibility.ConcreteHandlers;

namespace Patrones_Comportamiento.ChainOfResponsibility
{
    public partial class VistaChainOfResponsibility : UserControl
    {
        private readonly Dispensador cadena;

        public VistaChainOfResponsibility()
        {
            InitializeComponent();

            // Crear los dispensadores
            Dispensador bebidas = new DispensadorBebidas();

            Dispensador snacks = new DispensadorSnacks();

            Dispensador dulces = new DispensadorDulces();

            // Conectar la cadena
            bebidas.EstablecerSiguiente(snacks);

            snacks.EstablecerSiguiente(dulces);

            // Primer responsable
            cadena = bebidas;

            CmbProductos.SelectedIndex = 0;
        }

        private void BtnDispensar_Click(
            object sender,
            RoutedEventArgs e)
        {
            if (CmbProductos.SelectedItem
                is not ComboBoxItem opcion)
            {
                MessageBox.Show("Selecciona un producto.");
                return;
            }

            string producto = opcion.Content.ToString()!;

            List<string> recorrido = new List<string>();

            // La solicitud entra al primer dispensador
            string resultado =
                cadena.Dispensar(producto, recorrido);

            // Mostrar recorrido
            ListaRecorrido.Items.Clear();

            foreach (string dispensador in recorrido)
            {
                ListaRecorrido.Items.Add(dispensador);
            }

            // Mostrar resultado
            TxtResultado.Text = resultado;
        }
    }
}
