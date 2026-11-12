
using System;
using System.Windows;
using System.Windows.Controls;

using Patrones_Comportamiento.Command.Modelos;
using Patrones_Comportamiento.Command.Receiver;
using Patrones_Comportamiento.Command.Invoker;
using Patrones_Comportamiento.Command.ConcreteCommands;

namespace Patrones_Comportamiento.Command
{
    public partial class VistaCommand : UserControl
    {
        private bool hayConexion = false;

        private readonly ServidorVeterinario servidor =
            new ServidorVeterinario();

        private readonly ColaSincronizacion cola =
            new ColaSincronizacion();

        public VistaCommand()
        {
            InitializeComponent();

            CmbTratamiento.SelectedIndex = 0;

            ActualizarVista();
        }

        private void BtnConexion_Click(
            object sender,
            RoutedEventArgs e)
        {
            hayConexion = !hayConexion;

            TxtMensaje.Text = hayConexion
                ? "Conexión disponible. Puedes sincronizar."
                : "Sin conexión. Los registros quedarán pendientes.";

            ActualizarVista();
        }

        private void BtnRegistrar_Click(
            object sender,
            RoutedEventArgs e)
        {
            string arete = TxtArete.Text.Trim();

            if (string.IsNullOrWhiteSpace(arete))
            {
                MessageBox.Show(
                    "Ingresa el arete del animal.");

                return;
            }

            if (CmbTratamiento.SelectedItem
                is not ComboBoxItem opcion)
            {
                MessageBox.Show(
                    "Selecciona un tratamiento.");

                return;
            }

            // Crear los datos del registro
            RegistroTratamiento registro =
                new RegistroTratamiento
                {
                    Arete = arete,
                    Tratamiento = opcion.Content.ToString()!
                };

            // Crear el comando
            RegistrarTratamientoCommand comando =
                new RegistrarTratamientoCommand(
                    servidor,
                    registro);

            // Guardar el comando para después
            cola.Agregar(comando);

            TxtMensaje.Text =
                "Tratamiento registrado como pendiente.";

            ActualizarVista();
        }

        private void BtnSincronizar_Click(
            object sender,
            RoutedEventArgs e)
        {
            if (!hayConexion)
            {
                MessageBox.Show(
                    "No hay conexión a internet.",
                    "Sin conexión");

                return;
            }

            try
            {
                int cantidad = cola.Sincronizar(hayConexion);

                TxtMensaje.Text =
                    cantidad + " registro(s) sincronizado(s).";
            }
            catch (Exception ex)
            {
                TxtMensaje.Text =
                    "No se pudo completar la sincronización: "
                    + ex.Message;
            }

            ActualizarVista();
        }

        private void ActualizarVista()
        {
            TxtConexion.Text = hayConexion
                ? "Con conexión"
                : "Sin conexión";

            TxtPendientes.Text =
                cola.Pendientes.Count.ToString();

            TxtSincronizados.Text =
                servidor.Registros.Count.ToString();

            // Mostrar comandos pendientes
            ListaPendientes.Items.Clear();

            foreach (var comando in cola.Pendientes)
            {
                ListaPendientes.Items.Add(
                    comando.Descripcion);
            }

            // Mostrar registros sincronizados
            ListaSincronizados.Items.Clear();

            foreach (var registro in servidor.Registros)
            {
                ListaSincronizados.Items.Add(
                    registro.Arete + " - " +
                    registro.Tratamiento);
            }
        }
    }
}
